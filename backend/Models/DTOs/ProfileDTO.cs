using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace origami_backend.Models.DTOs
{
    public class ProfileDTO
    {
        public string Username { get; set; }
        public string PicturePath { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public string Description { get; set; }
        public ICollection<CommentDTO> Comments { get; set; }

        public ProfileDTO(User user)
        {
            Username = user.Username;
            PicturePath = user.PicturePath;
            FirstName = user.Profile.FirstName;
            LastName = user.Profile.LastName;
            Birthday = user.Profile.Birthday;
            Description = user.Profile.Description;
            Comments = new List<CommentDTO>();

            foreach (var comment in user.Profile.ProfileComments)
            {
                Comments.Add(new CommentDTO
                {
                    Id = comment.Id,
                    CommenterUsername = comment.User.Username,
                    ProfileUsername = user.Username,
                    PicturePath = comment.User.PicturePath,
                    Body = comment.Body,
                    DateUpdated = comment.DateUpdated
                });
            }
        }
    }
}
