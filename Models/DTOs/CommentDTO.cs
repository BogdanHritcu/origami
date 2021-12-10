using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace origami_backend.Models.DTOs
{
    public class CommentDTO
    {
        public string Username { get; set; }
        public string PicturePath { get; set; }
        public string Body { get; set; }
    }
}
