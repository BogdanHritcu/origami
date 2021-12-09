using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace origami_backend.Models
{
    public class OrigamiComment : BaseEntity
    {
        public Guid? UserId { get; set; }
        public Guid OrigamiId { get; set; }
        public string Body { get; set; }

        // relations
        public virtual User User { get; set; }
        public virtual Origami Origami { get; set; }
    }
}
