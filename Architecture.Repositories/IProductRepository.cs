using Architecture.Database.Entities;
using Architecture.Repositories.Common;
using System.Linq;

namespace Architecture.Repositories
{
    public interface IProductRepository : IIndexedRepository<Product>
    {
        IQueryable<Product> WithBrand(IQueryable<Product> entities);

        IQueryable<Product> WithCategories(IQueryable<Product> entities);

        IQueryable<Product> WithRatings(IQueryable<Product> entities);

        void Remove(int id);
    }
}
