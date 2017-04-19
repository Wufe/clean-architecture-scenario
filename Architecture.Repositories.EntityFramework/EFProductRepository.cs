using Architecture.Repositories.EntityFramework.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Architecture.Repositories.Product;
using Architecture.Database.Entities;
using System.Linq;

namespace Architecture.Repositories.EntityFramework
{
    public class EFProductRepository : EFRepository<Database.Entities.Product>, IProductRepository
    {
        public EFProductRepository(DbContext context) : base(context)
        {
        }

        public IQueryable<Database.Entities.Product> WithBrand(IQueryable<Database.Entities.Product> entities)
        {
            return
                entities
                    .Include(x => x.Brand);
        }

        public IQueryable<Database.Entities.Product> WithCategories(IQueryable<Database.Entities.Product> entities)
        {
            return
                entities
                    .Include(x => x.ProductCategories)
                        .ThenInclude(pc => pc.Category);
        }

        public IQueryable<Database.Entities.Product> WithRatings(IQueryable<Database.Entities.Product> entities)
        {
            return
                entities
                    .Include(x => x.Ratings)
                        .ThenInclude(r => r.User);
        }
    }
}
