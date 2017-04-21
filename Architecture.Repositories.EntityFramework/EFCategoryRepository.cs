using Architecture.Repositories.EntityFramework.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Architecture.Repositories.Category;
using Architecture.Database.Entities;
using System.Linq;

namespace Architecture.Repositories.EntityFramework
{
    public class EFCategoryRepository : EFIndexedRepository<Database.Entities.Category>, ICategoryRepository
    {
        public EFCategoryRepository(DbContext context) : base(context)
        {
        }

        public IQueryable<Database.Entities.Category> WithProducts(IQueryable<Database.Entities.Category> entities)
        {
            return
                entities
                    .Include(x => x.ProductCategories)
                        .ThenInclude(pc => pc.Product);
        }
    }
}
