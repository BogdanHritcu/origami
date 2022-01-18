using origami_backend.Data;
using origami_backend.Models;
using origami_backend.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace origami_backend.Repositories
{
    public class OrigamiCommentRepository : GenericRepository<OrigamiComment>, IOrigamiCommentRepository
    {
        public OrigamiCommentRepository(Context context) : base(context)
        {

        }
    }
}
