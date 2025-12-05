using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OgrenciServis.Logic.Interface;
using OgrenciServis.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciServis.Logic.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IConfiguration configuration;

        public JwtTokenService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            // Secret key oku
            var secretKey = this.configuration["Jwt:SecretKey"];
            // Secret key byte dizine cevirir
            var key =Encoding.UTF8.GetBytes(secretKey);
            // token tanımlama
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //Claim bilgileri ekle
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                    {
                    new System.Security.Claims.Claim("UserId", user.UserId.ToString()),
                   new System.Security.Claims.Claim("UserName", user.UserName),
                   new System.Security.Claims.Claim("Role", user.Role),
                   new System.Security.Claims.Claim("EMail","ertugrulkra@gmail.com"),
                   
                }),
                //Token süresi
                Expires = DateTime.UtcNow.AddDays(1),
                //İmzalama
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            // Token oluşturma adımı
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            // Token'
            return tokenHandler.WriteToken(token);
        }
    }
}
