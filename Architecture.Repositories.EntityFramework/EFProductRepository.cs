using Architecture.Repositories.EntityFramework.Common;
using Microsoft.EntityFrameworkCore;
using Architecture.Database.Entities;
using System.Linq;

namespace Architecture.Repositories.EntityFramework
{
    public class EFProductRepository : EFIndexedRepository<Product>, IProductRepository
    {
        public EFProductRepository(DbContext context) : base(context)
        {
        }

        public IQueryable<Product> WithBrand(IQueryable<Product> entities)
        {
            return
                entities
                    .Include(x => x.Brand);
        }

        public IQueryable<Product> WithCategories(IQueryable<Product> entities)
        {
            return
                entities
                    .Include(x => x.ProductCategories)
                        .ThenInclude(pc => pc.Category);
        }

        public IQueryable<Product> WithRatings(IQueryable<Product> entities)
        {
            return
                entities
                    .Include(x => x.Ratings)
                        .ThenInclude(r => r.User);
        }

        public void Remove(int id)
        {
            var product = new Product
            {
                Id = id
            };
            Attach(ref product,
                p =>
                    p.Id == id
            );
            _context.Set<Product>().Remove(product);
        }
    }
}
