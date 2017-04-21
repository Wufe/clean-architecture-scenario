using Architecture.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Architecture.Repositories.Product
{
    public interface IProductRepository : IIndexedRepository<Database.Entities.Product>
    {
        IQueryable<Database.Entities.Product> WithBrand(IQueryable<Database.Entities.Product> entities);

        IQueryable<Database.Entities.Product> WithCategories(IQueryable<Database.Entities.Product> entities);

        IQueryable<Database.Entities.Product> WithRatings(IQueryable<Database.Entities.Product> entities);
    }
}
