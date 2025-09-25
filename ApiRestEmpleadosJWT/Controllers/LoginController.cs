using ApiRestEmpleadosJWT.Interfaces;
using ApiRestEmpleadosJWT.Models;
using Microsoft.AspNetCore.Mvc;


namespace ApiRestEmpleadosJWT.Controllers
{
    [Route("auth/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginService _ls;

        public LoginController(ILoginService loginService)
        {
            _ls = loginService;

        }


        // POST
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginDTO lgnDTO)
        {
            try
            {
                TokenDTO tokenDTO = await _ls.LoginAsync(lgnDTO);
                if (tokenDTO == null)
                {
                    return BadRequest("Usuario o clave incorrecta");
                }
                else
                {

                    return Ok(tokenDTO);
                }

            }
            catch (Exception ex)
            {

                throw;
            }

        }

 
    }
}
