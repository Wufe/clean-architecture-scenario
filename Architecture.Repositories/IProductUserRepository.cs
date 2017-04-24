using Architecture.Database.Entities.Shared;
using Architecture.Repositories.Common;
using System.Linq;

namespace Architecture.Repositories
{
    public interface IProductUserRepository : IIndexedRepository<ProductUser>
    {
        IQueryable<ProductUser> WithProducts(IQueryable<ProductUser> entities);
    }
}
