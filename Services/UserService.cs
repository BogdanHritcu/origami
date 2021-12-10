using origami_backend.Models;
using origami_backend.Utilities;
using origami_backend.Utilities.JWTUtilis;
using BCryptNet = BCrypt.Net.BCrypt;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using origami_backend.Repositories;
using origami_backend.Models.DTOs.Login;
using origami_backend.Models.DTOs.Register;

namespace origami_backend.Services
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository;
        private IJWTUtils _JWtUtils;
        private readonly AppSettings _appSettings;

        public UserService(IUserRepository userRepository, IJWTUtils JWtUtils, IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _JWtUtils = JWtUtils;
            _appSettings = appSettings.Value;
        }

        public LoginResponseDTO Authenticate(LoginRequestDTO req)
        {
            var user = _userRepository.GetByUsername(req.Username);

            if(user == null || !BCryptNet.Verify(req.Password, user.PasswordHash))
            {
                return null;
            }

            var jwtToken = _JWtUtils.GenerateToken(user);
            return new LoginResponseDTO(user, jwtToken);
        }

        public LoginResponseDTO Register(RegisterRequestDTO req)
        {
            var user = _userRepository.GetByUsername(req.Username);
            if (user != null)
            {
                return null;
            }

            user = new User
            {
                Username = req.Username,
                PasswordHash = BCryptNet.HashPassword(req.Password),
                HashSalt = BCryptNet.GenerateSalt(),
                Email = req.Email,
                Role = Role.User
            };

            _userRepository.Create(user);
            bool success = _userRepository.Save();
            
            if (!success)
            {
                return null;
            }

            var jwtToken = _JWtUtils.GenerateToken(user);
            return new LoginResponseDTO(user, jwtToken);
        }

        public User GetByUsername(string username)
        {
            return _userRepository.GetByUsername(username);
        }

        public User GetById(Guid id)
        {
            return _userRepository.Get(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAll().ToList();
        }
    }
}
