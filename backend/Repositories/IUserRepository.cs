using origami_backend.Models;
using origami_backend.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace origami_backend.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetByUsername(string username);
        User GetByUsernameIncludingProfile(string username);
    }
}
