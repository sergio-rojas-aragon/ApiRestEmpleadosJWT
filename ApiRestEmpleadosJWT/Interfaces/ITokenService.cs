using ApiRestEmpleadosJWT.Models;

namespace ApiRestEmpleadosJWT.Interfaces
{
    public interface ITokenService
    {
        TokenDTO GetToken(UsuarioDTO usr);
    }
}
