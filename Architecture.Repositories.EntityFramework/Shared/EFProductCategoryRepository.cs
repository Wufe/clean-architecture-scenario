using Architecture.Database.Entities.Shared;
using Architecture.Repositories.EntityFramework.Common;
using Microsoft.EntityFrameworkCore;

namespace Architecture.Repositories.EntityFramework.Shared
{
    public class EFProductCategoryRepository : EFRepository<ProductCategory>, IProductCategoryRepository
    {
        public EFProductCategoryRepository(DbContext context) : base(context)
        {
        }

        public void Remove(int productId, int categoryId)
        {
            var productCategory = new ProductCategory
            {
                ProductId = productId,
                CategoryId = categoryId
            };
            Attach(ref productCategory,
                pc => 
                    pc.ProductId == productId &&
                    pc.CategoryId == categoryId
            );
            _context.Set<ProductCategory>().Remove(productCategory);
        }
    }
}
