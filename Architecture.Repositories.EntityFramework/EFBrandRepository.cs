using Architecture.Database.Entities;
using Architecture.Repositories.EntityFramework.Common;
using Microsoft.EntityFrameworkCore;

namespace Architecture.Repositories.EntityFramework
{
    public class EFBrandRepository : EFIndexedRepository<Brand>, IBrandRepository
    {
        public EFBrandRepository(DbContext context) : base(context)
        {
        }
    }
}
