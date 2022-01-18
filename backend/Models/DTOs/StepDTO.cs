using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace origami_backend.Models.DTOs
{
    public class StepDTO
    {
        public string Description { get; set; }
        public string PicturePath { get; set; }
        public int Number { get; set; }
    }
}
