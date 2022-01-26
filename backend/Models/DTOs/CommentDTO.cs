using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace origami_backend.Models.DTOs
{
    public class CommentDTO
    {
        public Guid Id { get; set; }
        public string CommenterUsername { get; set; }
        public string ProfileUsername { get; set; }
        public string PicturePath { get; set; }
        public string Body { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
