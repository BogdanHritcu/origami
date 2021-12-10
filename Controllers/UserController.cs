using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCryptNet = BCrypt.Net.BCrypt;
using origami_backend.Models;
using origami_backend.Services;
using origami_backend.Models.DTOs.Login;
using origami_backend.Models.DTOs.Register;
using origami_backend.Utilities.Attributes;

namespace origami_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(LoginRequestDTO req)
        {
            var response = _userService.Authenticate(req);

            if (response == null)
            {
                return BadRequest(new { Message = "Invalid username or password!" });
            }

            return Ok(response);
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequestDTO req)
        {
            var response = _userService.Register(req);

            if (response == null)
            {
                return BadRequest(new { Message = "Username already exists!" });
            }

            return Ok(response);
        }

        [Authorization(Role.Admin)]
        [HttpGet("all")]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }
    }
}
