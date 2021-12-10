using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace origami_backend.Models.DTOs.Login
{
    public class LoginResponseDTO
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }

        public LoginResponseDTO(User user, string token)
        {
            Id = user.Id;
            Username = user.Username;
            Token = token;
        }
    }
}
