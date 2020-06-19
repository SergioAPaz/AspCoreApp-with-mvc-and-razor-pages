using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyApi.Models;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly CRUDAPPContext _context;

        // TRAEMOS EL OBJETO DE CONFIGURACIÓN (appsettings.json)
        // MEDIANTE INYECCIÓN DE DEPENDENCIAS.
        public LoginController(IConfiguration configuration,CRUDAPPContext context)
        {
            this.configuration = configuration;
            _context = context;
        }

        // POST: api/Login
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UsuarioLogin usuarioLogin)
        {
            var _userInfo = await AutenticarUsuarioAsync(usuarioLogin.Usuario, usuarioLogin.Password);
            if (_userInfo != null)
            {
                return Ok(new { token = GenerarTokenJWT(_userInfo) });
            }
            else
            {
                return Unauthorized();
            }
        }

        // VALIDA SI EL USUARIO EXISTE EN LA BASE DE DATOS 
        private async Task<CtUsers> AutenticarUsuarioAsync(string usuario, string password)
        {          
                var confirmAccess = _context.CtUsers.Where(x => x.UserName.ToLower() == usuario.ToLower() & x.Password == password).FirstOrDefault();

                if (confirmAccess != null)
                {
                    return new CtUsers()
                    {
                        // Id del Usuario en el Sistema de Información (BD)
                        Id = confirmAccess.Id,
                        UserName = confirmAccess.UserName
                    };
                }
                else
                {
                    return null;
                }            
        }

        // GENERAMOS EL TOKEN CON LA INFORMACIÓN DEL USUARIO
        private string GenerarTokenJWT(CtUsers usuarioInfo)
        {
            // CREAMOS EL HEADER //
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["JWT:ClaveSecreta"])
                );
            var _signingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                );
            var _Header = new JwtHeader(_signingCredentials);

            // CREAMOS LOS CLAIMS //
            var _Claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, usuarioInfo.Id.ToString()),
                new Claim("nombre", usuarioInfo.UserName)
            };

            // CREAMOS EL PAYLOAD //
            var _Payload = new JwtPayload(
                    issuer: configuration["JWT:Issuer"],
                    audience: configuration["JWT:Audience"],
                    claims: _Claims,
                    notBefore: DateTime.UtcNow,
                    // Exipra a la 24 horas.
                    expires: DateTime.UtcNow.AddHours(24)
                );

            // GENERAMOS EL TOKEN //
            var _Token = new JwtSecurityToken(
                    _Header,
                    _Payload
                );

            return new JwtSecurityTokenHandler().WriteToken(_Token);

        }
    }
}