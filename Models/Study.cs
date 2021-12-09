using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace origami_backend.Models
{
    public enum Status { Planned, Working, Done, GaveUp }
    public class Study : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid OrigamiId { get; set; }
        public Status Status { get; set; }
        public int Score { get; set; }
        public bool Favorite { get; set; }
        public DateTime? DateStarted { get; set; }
        public DateTime? DateFinished { get; set; }
    }
}
