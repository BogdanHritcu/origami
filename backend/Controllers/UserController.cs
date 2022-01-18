using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCryptNet = BCrypt.Net.BCrypt;
using origami_backend.Models;
using origami_backend.Services;
using origami_backend.Models.DTOs;
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

        [HttpPost("login")]
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

        [HttpPost("profile/{username}")]
        public IActionResult PostCommet(string username, CommentDTO comment)
        {
            var myUser = (User)HttpContext.Items["User"];
            if (myUser == null)
            {
                return BadRequest(new { Message = "Need to login first!" });
            }

            var response = _userService.PostComment(myUser.Username, username, comment);

            if (response == null)
            {
                return BadRequest(new { Message = "Something went wrong!" });
            }
            return Ok(response);
        }

        [HttpGet("profile/{username}")]
        public IActionResult GetProfile(string username)
        {
            var response = _userService.GetProfileDTO(username);
            if (response == null)
            {
                return BadRequest(new { Message = "User does not exist!" });
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
