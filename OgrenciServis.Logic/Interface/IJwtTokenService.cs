using OgrenciServis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciServis.Logic.Interface
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user);
    }
}
