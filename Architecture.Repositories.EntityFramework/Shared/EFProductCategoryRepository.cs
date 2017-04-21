using Architecture.Database.Entities.Shared;
using Architecture.Repositories.EntityFramework.Common;
using Architecture.Repositories.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Architecture.Repositories.EntityFramework.Shared
{
    public class EFProductCategoryRepository : EFRepository<ProductCategory>, IProductCategoryRepository
    {
        public EFProductCategoryRepository(DbContext context) : base(context)
        {
        }
    }
}
