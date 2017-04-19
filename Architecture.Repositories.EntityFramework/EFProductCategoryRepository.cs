using Architecture.Database.Entities;
using Architecture.Repositories.EntityFramework.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Architecture.Repositories.Shared;

namespace Architecture.Repositories.EntityFramework
{
    public class EFProductCategoryRepository : EFRepository<ProductCategory>, IProductCategoryRepository
    {
        public EFProductCategoryRepository(DbContext context) : base(context)
        {
        }
    }
}
