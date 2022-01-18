using origami_backend.Models;
using origami_backend.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace origami_backend.Services
{
    public interface IOrigamiService
    {
        OrigamiDTO Create(OrigamiDTO req);
        Origami Get(Guid id);
        Origami GetByName(string name);
        OrigamiDTO GetOrigamiDTO(Guid id);
        OrigamiDTO GetByNameOrigamiDTO(string name);
        CommentDTO PostComment(
            string commenterUsername,
            Guid origamiId,
            CommentDTO comment);
        IEnumerable<OrigamiDTO> GetUserCreatedOrigamis(string username);
    }
}
