using origami_backend.Models;
using origami_backend.Utilities;
using origami_backend.Utilities.JWTUtilis;
using BCryptNet = BCrypt.Net.BCrypt;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using origami_backend.Repositories;
using origami_backend.Models.DTOs;

namespace origami_backend.Services
{
    public class OrigamiService : IOrigamiService
    {
        public IOrigamiRepository _origamiRepository;
        public IUserRepository _userRepository;
        public IStepRepository _stepRepository;
        public IOrigamiCommentRepository _origamiCommentRepository;

        public OrigamiService(
            IOrigamiRepository origamiRepository,
            IUserRepository userRepository,
            IStepRepository stepRepository,
            IOrigamiCommentRepository origamiCommentRepository)
        {
            _origamiRepository = origamiRepository;
            _userRepository = userRepository;
            _stepRepository = stepRepository;
            _origamiCommentRepository = origamiCommentRepository;
        }

        public OrigamiDTO Create(OrigamiDTO req)
        {
            var user = _userRepository.GetByUsername(req.Username);

            if (user == null)
            {
                return null;
            }

            var origami = new Origami()
            {
                UserId = user.Id,
                Name = req.Name,
                PicturePath = req.PicturePath,
                Description = req.Description,
                VideoPath = req.VideoPath,
                Difficulty = req.Difficulty,
                EstimatedTime = req.EstimatedTime
            };

            _origamiRepository.Create(origami);
            bool success = _origamiRepository.Save();

            if (!success)
            {
                return null;
            }

            ICollection<Step> steps = new List<Step>();

            foreach (var stepDTO in req.Steps)
            {
                steps.Add(new Step()
                {
                    OrigamiId = origami.Id,
                    Name = req.Name,
                    Description = stepDTO.Description,
                    PicturePath = stepDTO.PicturePath,
                    Number = stepDTO.Number
                });
            }
            _stepRepository.CreateRange(steps);

            success = _stepRepository.Save();

            if (!success)
            {
                return null;
            }

            return req;
        }

        public Origami Get(Guid id)
        {
            return _origamiRepository.GetIncludingSteps(id);
        }

        public Origami GetByName(string name)
        {
            return _origamiRepository.GetByNameIncludingSteps(name);
        }

        public OrigamiDTO GetOrigamiDTO(Guid id)
        {
            var origami = _origamiRepository.GetIncludingComments(id);
            if (origami == null)
            {
                return null;
            }

            return new OrigamiDTO(origami);
        }

        public OrigamiDTO GetByNameOrigamiDTO(string name)
        {
            var origami = _origamiRepository.GetByNameIncludingComments(name);
            if (origami == null)
            {
                return null;
            }
             
            return new OrigamiDTO(origami);
        }

        public CommentDTO PostComment(
            string commenterUsername,
            Guid origamiId,
            CommentDTO comment)
        {
            var origami = _origamiRepository.Get(origamiId);
            if (origami == null)
            {
                return null;
            }

            var commenterUser = _userRepository.GetByUsername(commenterUsername);
            if (commenterUser == null)
            {
                return null;
            }

            var origamiComment = new OrigamiComment
            {
                UserId = commenterUser.Id,
                OrigamiId = origamiId,
                Body = comment.Body
            };

            _origamiCommentRepository.Create(origamiComment);
            bool success = _origamiCommentRepository.Save();

            if (!success)
            {
                return null;
            }

            return comment;
        }

        public CommentDTO DeleteComment(CommentDTO commentDTO)
        {
            var comment = _origamiCommentRepository.Get(commentDTO.Id);
            if (comment == null)
            {
                return commentDTO;
            }

            _origamiCommentRepository.Delete(comment);
            bool success = _origamiCommentRepository.Save();

            if (!success)
            {
                return null;
            }

            return commentDTO;
        }

        public IEnumerable<OrigamiDTO> GetUserCreatedOrigamis(string username)
        {
            var user = _userRepository.GetByUsername(username);

            if (user == null)
            {
                return null;
            }

            var userOrigamis = _origamiRepository.GetAllFromUsername(username);

            var origamiDTOs = new List<OrigamiDTO>();
            
            foreach (var origami in userOrigamis)
            {
                origamiDTOs.Add(new OrigamiDTO(origami));
            }

            return origamiDTOs;
        }
    }
}
