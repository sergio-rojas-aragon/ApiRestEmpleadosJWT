using ApiRestEmpleadosJWT.Interfaces;
using ApiRestEmpleadosJWT.Models;

namespace ApiRestEmpleadosJWT.Services
{
    public class UsuarioService : IUsuarioService
    {
        public async Task<UsuarioDTO?> GetbyClv( string usuario, string clave)
        {
            //simulo consulta a usuario
            UsuarioDTO _usuario = new UsuarioDTO();

            if (clave == "1234" && usuario == "admin")
            {
                _usuario.clave = "admin / 1234";
                _usuario.usuario = usuario;
                _usuario.nombreUsuario = "Juanito";
                return _usuario;
            }
            else
            {
                return null;
            }
        }
    }
}
