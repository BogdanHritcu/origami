using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace origami_backend.Models
{
    public class Origami
    {
        public string Name { get; set; }
        public string Difficulty { get; set; }
        public int EstimatedTime { get; set; } // seconds
    }
}
