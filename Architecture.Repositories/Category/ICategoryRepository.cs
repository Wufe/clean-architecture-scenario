using Architecture.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Architecture.Repositories.Category
{
    public interface ICategoryRepository : IIndexedRepository<Database.Entities.Category>
    {
        IQueryable<Database.Entities.Category> WithProducts(IQueryable<Database.Entities.Category> entities);
    }
}
