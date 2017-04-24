using Architecture.Database.Entities.Shared;
using Architecture.Repositories.Common;

namespace Architecture.Repositories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        void Remove(int productId, int categoryId);
    }
}
