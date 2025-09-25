using ApiRestEmpleadosJWT.Interfaces;
using ApiRestEmpleadosJWT.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiRestEmpleadosJWT.Services
{
    public class TokenService : ITokenService
    {
        public TokenDTO GetToken(UsuarioDTO usr)
        {
            // podrian ser funciones separadas pero lo hare aca mismo para generar los claims
            List<Claim> _lstClaim = new List<Claim>();
            _lstClaim.Add(new Claim("nombreUsuario", usr.nombreUsuario.ToString()));

            // encriptacion
            var key = "aKLMSLK3I4JNKNDKJFNKJN545N4J5N4J54H4G44H5JBSSDBNF3453S2223KJNF";
            var sskey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            var cfirma = new SigningCredentials(sskey, SecurityAlgorithms.HmacSha256);

            var fechaVencimiento = DateTime.UtcNow.AddHours(1);

            var token = new JwtSecurityToken(
                claims: _lstClaim,
                expires: fechaVencimiento,
                signingCredentials: cfirma
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            TokenDTO lgn = new TokenDTO();
            lgn.access_token = jwt;

            return lgn;
        }
    }
}
