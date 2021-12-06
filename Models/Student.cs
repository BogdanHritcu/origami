using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace origami_backend.Models
{
    public class Student : User
    {
        public string Grade { get; set; }
        public string Skill { get; set; }
    }
}
