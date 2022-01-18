using origami_backend.Models;
using origami_backend.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace origami_backend.Repositories
{
    public interface IOrigamiRepository : IGenericRepository<Origami>
    {
        Origami GetIncludingSteps(Guid id);
        Origami GetByNameIncludingSteps(string name);
        Origami GetIncludingComments(Guid id);
        Origami GetByNameIncludingComments(string name);
        IQueryable<Origami> GetAllFromUsername(string username);
    }
}
