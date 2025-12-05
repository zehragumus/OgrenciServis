using OgrenciServis.DataAccess;
using OgrenciServis.Logic.Interface;
using OgrenciServis.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciServis.Logic.Services
{
    public class AuthService : 
        IAuthService
    {
        private readonly OkulContext _context;
        private readonly IJwtTokenService _jwtTokenService;


        public AuthService(OkulContext context, IJwtTokenService jwtTokenService)
        {
            _context = context;
            _jwtTokenService = jwtTokenService;
        }

        public LoginResponseDto? Login(LoginRequestDto loginRequest)
        {
            var user = (from u in _context.Users
                        where u.UserName == loginRequest.Username
                        select u).FirstOrDefault();
            if (user == null)
                return null;

            if (user.Password != loginRequest.Password) 
                return null;

            var token = _jwtTokenService.GenerateToken(user);

            return new LoginResponseDto
            {
                Token = token,
                Username = user.UserName,
                Role = user.Role,
                ExpiresAt = DateTime.UtcNow.AddDays(1)
            };

        }
    }
}
