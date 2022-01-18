using origami_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace origami_backend.Utilities.JWTUtilis
{
    public interface IJWTUtils
    {
        public string GenerateToken(User user);
        public Guid ValidateToken(string token);
    }
}
