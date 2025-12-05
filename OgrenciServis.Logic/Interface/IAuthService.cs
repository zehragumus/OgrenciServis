using OgrenciServis.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciServis.Logic.Interface
{
    public interface IAuthService
    {
        LoginResponseDto? Login(LoginRequestDto loginRequest);
     
    }
}
