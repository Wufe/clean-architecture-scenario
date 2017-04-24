using Architecture.Database.Entities;
using Architecture.Repositories.EntityFramework.Common;
using Microsoft.EntityFrameworkCore;

namespace Architecture.Repositories.EntityFramework
{
    public class EFUserRepository : EFIndexedRepository<User>, IUserRepository
    {
        public EFUserRepository(DbContext context) : base(context)
        {
        }
    }
}
