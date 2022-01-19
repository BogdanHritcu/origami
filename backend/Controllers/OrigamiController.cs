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
    public class OrigamiController : ControllerBase
    {
        private IOrigamiService _origamiService {get; set;} 
        public OrigamiController(IOrigamiService origamiService)
        {
            _origamiService = origamiService;
        }

        [HttpPost("create")]
        public IActionResult Create(OrigamiDTO req)
        {
            var myUser = (User)HttpContext.Items["User"];
            if (myUser == null)
            {
                return BadRequest(new { Message = "Need to login first!" });
            }
            req.Username = myUser.Username;

            var response = _origamiService.Create(req);
            if (response == null)
            {
                return BadRequest(new { Message = "Something went wrong!" });
            }

            return Ok(response);
        }

        [HttpPost("{id}")]
        public IActionResult PostComment(Guid id, CommentDTO comment)
        {
            var myUser = (User)HttpContext.Items["User"];
            if (myUser == null)
            {
                return BadRequest(new { Message = "Need to login first!" });
            }

            var response = _origamiService.PostComment(myUser.Username, id, comment);

            if (response == null)
            {
                return BadRequest(new { Message = "Something went wrong!" });
            }
            return Ok(response);
        }

        [HttpDelete("comment")]
        public IActionResult DeleteComment(CommentDTO commentDTO)
        {
            var myUser = (User)HttpContext.Items["User"];
            if (myUser == null || myUser.Username != commentDTO.Username)
            {
                return BadRequest(new { Message = "Need to login first!" });
            }

            var response = _origamiService.DeleteComment(commentDTO);

            if (response == null)
            {
                return BadRequest(new { Message = "Something went wrong!" });
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrigami(Guid id)
        {
            var response = _origamiService.GetOrigamiDTO(id);

            if (response == null)
            {
                return BadRequest(new { Message = "Something went wrong!" });
            }
            return Ok(response);
        }

        [HttpGet("creations/{username}")]
        public IActionResult GetUserCreations(string username)
        {
            var myUser = (User)HttpContext.Items["User"];
            if (myUser == null)
            {
                return BadRequest(new { Message = "Need to login first!" });
            }

            var response = _origamiService.GetUserCreatedOrigamis(username);

            if (response == null)
            {
                return BadRequest(new { Message = "Something went wrong!" });
            }
            return Ok(response);
        }
    }
}
