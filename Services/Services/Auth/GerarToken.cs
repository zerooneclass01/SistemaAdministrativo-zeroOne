using Dominio.Entidades;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration; 
using System;
using System.IdentityModel.Tokens.Jwt; 
using System.Security.Claims;
using System.Text;

namespace Services.Services.Auth
{
    public class GerarToken
    {
        private readonly IConfiguration _config;

        
        public GerarToken(IConfiguration config)
        {
            _config = config;
        }

        public string GerarTokenJwt(Usuario user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_config["Jwt:SecretKey"]!);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                    new Claim("id", user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}