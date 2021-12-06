using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using origami_backend.Models;

namespace origami_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        List<User> users = new List<User>
        {
            new User {Name = "Bog"},
            new User {Name = "Cog"},
            new User {Name = "Dog"}
        };

        [HttpGet("")]
        public User Get(int id)
        {
            return users.FirstOrDefault(s => s.Id.Equals(id));
        }
    }
}
