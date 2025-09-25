using ApiRestEmpleadosJWT.Interfaces;
using ApiRestEmpleadosJWT.Models;
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
        public async Task<IActionResult> Post([FromBody] EmpleadoDTO emp)
        {

            var _emp = await _es.CreateAsync(emp);
            if ( _emp == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "producto ya existe");
            }
            return Ok(_emp);

        }

        // PUT api/<EmpleadoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmpleadoDTO emp)
        {
            try
            {

                var _emp = await _es.UpdateAsync(id, emp);
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

        // DELETE api/<EmpleadoController>/5
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
