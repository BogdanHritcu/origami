using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using origami_backend.Models.Base;

namespace origami_backend.Models
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Displayname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
