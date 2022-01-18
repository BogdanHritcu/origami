using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace origami_backend.Models.DTOs
{
    public class OrigamiDTO
    {
        public string Username { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PicturePath { get; set; }
        public string Description { get; set; }
        public string VideoPath { get; set; }
        public Difficulty Difficulty { get; set; }
        public int EstimatedTime { get; set; }
        public ICollection<StepDTO> Steps { get; set; }
        public ICollection<CommentDTO> Comments { get; set; }
        public OrigamiDTO()
        {
        }
        public OrigamiDTO(Origami origami)
        {            
            Username = origami.User.Username;
            Id = origami.Id;
            Name = origami.Name;
            PicturePath = origami.PicturePath;
            Description = origami.Description;
            VideoPath = origami.VideoPath;
            Difficulty = origami.Difficulty;
            EstimatedTime = origami.EstimatedTime;
            Steps = new List<StepDTO>();
            Comments = new List<CommentDTO>();

            if (origami.Steps != null)
            {
                foreach (var step in origami.Steps)
                {
                    Steps.Add(new StepDTO
                    {
                        Description = step.Description,
                        PicturePath = step.PicturePath,
                        Number = step.Number
                    });
                }
            }

            if (origami.OrigamiComments != null)
            {
                foreach (var comment in origami.OrigamiComments)
                {
                    Comments.Add(new CommentDTO
                    {
                        Username = comment.User.Username,
                        PicturePath = comment.User.PicturePath,
                        Body = comment.Body
                    });
                }
            }
        }
    }
}
