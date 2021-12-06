using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace origami_backend.Models
{
    public class Admin : User 
    {
        public string Title { get; set; }
        public int Privilege { get; set; }
    }
}
