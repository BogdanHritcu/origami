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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {

        }

        public User GetByUsername(string username)
        {
            return _table.FirstOrDefault(x => x.Username.Equals(username));
        }

        public User GetByUsernameIncludingProfile(string username)
        {
            return _table.Include(x => x.Profile).FirstOrDefault(x => x.Username.Equals(username));
        }
    }
}
