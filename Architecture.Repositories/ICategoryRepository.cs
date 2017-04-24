using Architecture.Database.Entities;
using Architecture.Repositories.Common;
using System.Linq;

namespace Architecture.Repositories
{
    public interface ICategoryRepository : IIndexedRepository<Category>
    {
        IQueryable<Category> WithProducts(IQueryable<Category> entities);
        void Remove(int id);
    }
}
