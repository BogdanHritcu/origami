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
    public class ProfileController : ControllerBase
    {
        private IUserService _userService;

        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorization(Role.User, Role.Admin)]
        [HttpGet("me")]
        public IActionResult GetMyProfile()
        {
            var myUser = (User)HttpContext.Items["User"];
            if (myUser == null)
            {
                return BadRequest(new { Message = "Need to login first!" });
            }

            var response = _userService.GetProfileDTO(myUser.Username);
            if (response == null)
            {
                return BadRequest(new { Message = "User does not exist!" });
            }

            return Ok(response);
        }

        [HttpGet("{username}")]
        public IActionResult GetProfile(string username)
        {
            var response = _userService.GetProfileDTO(username);
            if (response == null)
            {
                return BadRequest(new { Message = "User does not exist!" });
            }

            return Ok(response);
        }

        [Authorization(Role.User, Role.Admin)]
        [HttpPost("comment")]
        public IActionResult PostComment(CommentDTO comment)
        {
            var myUser = (User)HttpContext.Items["User"];
            if (myUser == null || !myUser.Username.Equals(comment.CommenterUsername))
            {
                return BadRequest(new { Message = "Need to login first!" });
            }
           
            var response = _userService.PostComment(comment);

            if (response == null)
            {
                return BadRequest(new { Message = "Something went wrong!" });
            }
            return Ok(response);
        }

        [HttpPut("comment")]
        public IActionResult UpdateComment(CommentDTO comment)
        {
            var myUser = (User)HttpContext.Items["User"];
            if (myUser == null || !myUser.Username.Equals(comment.CommenterUsername))
            {
                return BadRequest(new { Message = "Need to login first!" });
            }

            var response = _userService.UpdateComment(comment);

            if (response == null)
            {
                return BadRequest(new { Message = "Something went wrong!" });
            }
            return Ok(response);
        }

        [Authorization(Role.User, Role.Admin)]
        [HttpDelete("comment")]
        public IActionResult DeleteComment(CommentDTO comment)
        {
            var myUser = (User)HttpContext.Items["User"];
            if (myUser == null || !myUser.Username.Equals(comment.CommenterUsername))
            {
                return BadRequest(new { Message = "Need to login first!" });
            }

            var response = _userService.DeleteComment(comment);

            if (response == null)
            {
                return BadRequest(new { Message = "Something went wrong!" });
            }
            return Ok(response);
        }
    }
}
