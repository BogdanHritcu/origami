using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace origami_backend.Models.DTOs
{
    public class LoginResponseDTO
    {
        public string Username { get; set; }
        public string Token { get; set; }

        public LoginResponseDTO(User user, string token)
        {
            Username = user.Username;
            Token = token;
        }
    }
}
