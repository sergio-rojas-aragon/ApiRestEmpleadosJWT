using ApiRestEmpleadosJWT.Models;

namespace ApiRestEmpleadosJWT.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO?> GetbyClv(string usuario, string clave);
    }
}
