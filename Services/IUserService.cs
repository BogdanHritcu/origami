using origami_backend.Models;
using origami_backend.Models.DTOs.Login;
using origami_backend.Models.DTOs.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace origami_backend.Services
{
    public interface IUserService
    {
        LoginResponseDTO Authenticate(LoginRequestDTO req);
        LoginResponseDTO Register(RegisterRequestDTO req);
        User GetByUsername(string username);
        User GetById(Guid id);
        IEnumerable<User> GetAllUsers();
    }
}
