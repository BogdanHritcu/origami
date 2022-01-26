using origami_backend.Models;
using origami_backend.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace origami_backend.Services
{
    public interface IUserService
    {
        LoginResponseDTO Authenticate(LoginRequestDTO req);
        LoginResponseDTO Register(RegisterRequestDTO req);
        User GetByUsername(string username);
        User Get(Guid id);
        ProfileDTO GetProfileDTO(string username);
        CommentDTO PostComment(CommentDTO comment);
        CommentDTO UpdateComment(CommentDTO comment);
        CommentDTO DeleteComment(CommentDTO commentDTO);
        IEnumerable<User> GetAllUsers();
    }
}
