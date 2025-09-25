using ApiRestEmpleadosJWT.Interfaces;
using ApiRestEmpleadosJWT.Models;
using ApiRestEmpleadosJWT.Validaciones;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRestEmpleadosJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadoService _es;

        public EmpleadosController(IEmpleadoService empleadoService)
        {
            _es = empleadoService;
        }

        // GET OK
        [HttpGet]
        public async Task<ActionResult<EmpleadoDTO>> Get()
        {
            try
            {
                var empleados = await _es.GetAsync();
                return Ok(empleados);                
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // GETBY OK
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var _emp = await _es.GetbyIdAsync(id);
                if (_emp == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(_emp);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // POST OK
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmpleadoCUDTO emp)
        {

            EmpleadoValidacion _ev = new EmpleadoValidacion();
            var val = _ev.Validate(emp);
            if (!val.IsValid)
            {
                List<ErroresDTO> errores = new List<ErroresDTO>();
                foreach (var failure in val.Errors)
                {

                    errores.Add(new ErroresDTO { errorStr = "Error en validacion en campo " + failure.PropertyName + ". Detalle del error: " + failure.ErrorMessage });
                }
                return StatusCode(StatusCodes.Status400BadRequest, errores);
            }

            var _emp = await _es.CreateAsync(new EmpleadoDTO { Cargo= emp.Cargo, Email=emp.Email, fechaIngreso=emp.fechaIngreso, nombreCompleto=emp.nombreCompleto  });

            return StatusCode(StatusCodes.Status201Created, _emp);

        }

        // PUT OK
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmpleadoCUDTO emp)
        {

            // validaciones

            EmpleadoValidacion _ev = new EmpleadoValidacion();
            var val = _ev.Validate(emp);
            if (!val.IsValid)
            {
                List<ErroresDTO> errores = new List<ErroresDTO>();
                foreach (var failure in val.Errors)
                {

                    errores.Add(new ErroresDTO { errorStr = "Error en validacion en campo " + failure.PropertyName + ". Detalle del error: " + failure.ErrorMessage });
                }
                return StatusCode(StatusCodes.Status400BadRequest, errores);
            }

            // actualizacion
            try
            {

                var _emp = await _es.UpdateAsync(id, new EmpleadoDTO { Cargo = emp.Cargo, Email = emp.Email, fechaIngreso = emp.fechaIngreso, nombreCompleto = emp.nombreCompleto });
                if (_emp == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(_emp);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        // DELETE OK
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var _emp = await _es.DeleteAsync(id);
            if (!_emp)
            {
                return NotFound();
            }
            else
            {
                return Ok(_emp);
            }
        }
    }
}
