using origami_backend.Data;
using origami_backend.Models;
using origami_backend.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace origami_backend.Repositories
{
    public class StepRepository : GenericRepository<Step>, IStepRepository
    {
        public StepRepository(Context context) : base(context)
        {
        }
    }
}
