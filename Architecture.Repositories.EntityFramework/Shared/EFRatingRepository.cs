using Architecture.Repositories.EntityFramework.Common;
using Microsoft.EntityFrameworkCore;
using Architecture.Repositories.Shared;
using Architecture.Database.Entities.Shared;

namespace Architecture.Repositories.EntityFramework.Shared
{
    public class EFRatingRepository : EFIndexedRepository<Rating>, IRatingRepository
    {
        public EFRatingRepository(DbContext context) : base(context)
        {
        }
    }
}
