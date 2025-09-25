using ApiRestEmpleadosJWT.Models;

namespace ApiRestEmpleadosJWT.Interfaces
{
    public interface ILoginService
    {
        Task<TokenDTO> LoginAsync(LoginDTO lgnDTO);
    }
}
