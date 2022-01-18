using Microsoft.EntityFrameworkCore;
using origami_backend.Data;
using origami_backend.Models;
using origami_backend.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace origami_backend.Repositories
{
    public class OrigamiRepository : GenericRepository<Origami>, IOrigamiRepository
    {
        public OrigamiRepository(Context context) : base(context)
        {

        }

        public Origami GetIncludingSteps(Guid id)
        {
            return _table.Include(x => x.User)
                .Include(x => x.Steps)
                .FirstOrDefault(x => x.Id.Equals(id));
        }

        public Origami GetByNameIncludingSteps(string name)
        {
            return _table.Include(x => x.User)
                .Include(x => x.Steps)
                .FirstOrDefault(x => x.Name.Equals(name));
        }

        public Origami GetIncludingComments(Guid id)
        {
            return _table.Include(x => x.User)
                .Include(x => x.Steps)
                .Include(x => x.OrigamiComments)
                .ThenInclude(x => x.User)
                .FirstOrDefault(x => x.Id.Equals(id));
        }

        public Origami GetByNameIncludingComments(string name)
        {
            return _table.Include(x => x.User)
                .Include(x => x.Steps)
                .Include(x => x.OrigamiComments)
                .ThenInclude(x => x.User)
                .FirstOrDefault(x => x.Name.Equals(name));
        }

        public IQueryable<Origami> GetAllFromUsername(string username)
        {
            return _table.Include(x => x.User)
                .Where(x => x.User.Username.Equals(username));
        }
    }
}
