using Architecture.Database.Entities;
using Architecture.Database.Entities.Shared;
using Architecture.Repositories.Common;
using System.Linq;

namespace Architecture.Repositories.Shared
{
    public interface IProductUserRepository : IIndexedRepository<ProductUser>
    {
        IQueryable<ProductUser> WithProducts(IQueryable<ProductUser> entities);
    }
}
