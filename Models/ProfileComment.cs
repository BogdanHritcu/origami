using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace origami_backend.Models
{
    public class ProfileComment : BaseEntity
    {
        public Guid? UserId { get; set; }
        public Guid ProfileId { get; set; }
        public string Body { get; set; }

        // relations
        public virtual User User { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
