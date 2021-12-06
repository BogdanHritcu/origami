using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using origami_backend.Models.Base;

namespace origami_backend.Models
{
    public class Study : BaseEntity
    {
        public string Status { get; set; }
        public DateTime? DateStarted { get; set; }
        public DateTime? DateEnded { get; set; }
        public float Raing { get; set; }
        public bool Favorite { get; set; }
    }
}
