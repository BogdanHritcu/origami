using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace origami_backend.Models
{
    public enum Theme { Dark, Light }
    public class Profile : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public string Description { get; set; }

        // relations
        public virtual User User { get; set; }
        public virtual ICollection<ProfileComment> ProfileComments { get; set; }
    }
}
