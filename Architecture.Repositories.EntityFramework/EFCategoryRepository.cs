using Architecture.Database.Entities;
using Architecture.Repositories.EntityFramework.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Architecture.Repositories.EntityFramework
{
    public class EFCategoryRepository : EFIndexedRepository<Category>, ICategoryRepository
    {
        public EFCategoryRepository(DbContext context) : base(context)
        {
        }

        public void Remove(int id)
        {
            var category = new Category
            {
                Id = id
            };
            Attach(ref category,
                c =>
                    c.Id == id
            );
            _context.Set<Category>().Remove(category);
        }

        public IQueryable<Category> WithProducts(IQueryable<Category> entities)
        {
            return
                entities
                    .Include(x => x.ProductCategories)
                        .ThenInclude(pc => pc.Product);
        }


    }
}
