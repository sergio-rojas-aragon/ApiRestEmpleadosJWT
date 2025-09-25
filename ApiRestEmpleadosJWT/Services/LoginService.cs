using ApiRestEmpleadosJWT.Interfaces;
using ApiRestEmpleadosJWT.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ApiRestEmpleadosJWT.Services
{
    public class LoginService : ILoginService
    {
        private AppDbContext _context;
        private UsuarioService _usuarioService;
        private TokenService _tokenService;

        public LoginService(AppDbContext context)
        {
            _context = context;
            _usuarioService = new UsuarioService();
            _tokenService = new TokenService();
        }
        public async Task<TokenDTO> LoginAsync(LoginDTO lgnDTO)
        {
            // compruebo si el usuario existe
            var usr = await _usuarioService.GetbyClv(lgnDTO.usuario, lgnDTO.clave);
            if (usr == null)
            {
                return null;
            }

            TokenDTO lgn = _tokenService.GetToken(usr);

            return lgn;
        }
    }
}
