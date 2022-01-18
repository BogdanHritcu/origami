using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace origami_backend.Models
{
    public enum Difficulty { Easy, Medium, Hard }
    public class Origami : BaseEntity
    {
        public Guid? UserId { get; set; }
        public string Name { get; set; }
        public string PicturePath { get; set; }
        public string Description { get; set; }
        public string VideoPath { get; set; }
        public Difficulty Difficulty { get; set; }
        public int EstimatedTime { get; set; }

        // relations
        public virtual User User { get; set; }
        public virtual ICollection<Study> Studies { get; set; }
        public virtual ICollection<Step> Steps { get; set; }
        public virtual ICollection<OrigamiComment> OrigamiComments { get; set; }
    }
}
