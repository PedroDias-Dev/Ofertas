using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Ofertas.Comum.Commands;
using Ofertas.Dominio.Commands.Usuario;
using Ofertas.Dominio.Entidades;
using Ofertas.Dominio.Handlers.Usuarios;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ofertas.Api.Controllers
{
    public class UsuarioController : Controller
    {
        [Route("signup")]
        [HttpPost]
        public GenericCommandResult SignUp([FromBody] CriarContaCommand command, [FromServices] CriarUsuarioHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("signin")]
        [HttpPost]
        public GenericCommandResult SignIn([FromBody] LoginCommand command, [FromServices] LoginCommandHandler handler)
        {
            var resultado = (GenericCommandResult)handler.Handle(command);

            if (resultado.Sucesso)
            {
                var token = GerarJSONWebToken((Usuario)resultado.Data);

                return new GenericCommandResult(resultado.Sucesso, resultado.Mensagem, new { token = token });
            }

            return new GenericCommandResult(false, resultado.Mensagem, resultado.Data);
        }
        private string GerarJSONWebToken(Usuario userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ChaveSecretaPartilhadoApi"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.FamilyName, userInfo.Nome),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(ClaimTypes.Role, userInfo.TipoUsuario.ToString()),
                new Claim("role", userInfo.TipoUsuario.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, userInfo.Id.ToString())
            };

            var token = new JwtSecurityToken
                (
                    "partilhado",
                    "partilhado",
                    claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
