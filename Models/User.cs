using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace origami_backend.Models
{
    public enum Role { Admin, User }
    public class User : BaseEntity
    {
        public Guid? ProfileId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string HashSalt { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public string PicturePath { get; set; }

        // relations
        public virtual Profile Profile { get; set; }
        public virtual ICollection<Origami> Origamis { get; set; }
        public virtual ICollection<Study> Studies { get; set; }
        public virtual ICollection<OrigamiComment> OrigamiComments { get; set; }
        public virtual ICollection<ProfileComment> ProfileComments { get; set; }
    }
}
