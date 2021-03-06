﻿using System.Linq;
using Architecture.Repositories.EntityFramework.Common;
using Microsoft.EntityFrameworkCore;
using Architecture.Database.Entities.Shared;

namespace Architecture.Repositories.EntityFramework.Shared
{
    public class EFProductUserRepository : EFIndexedRepository<ProductUser>, IProductUserRepository
    {
        public EFProductUserRepository(DbContext context) : base(context)
        {
        }

        public IQueryable<ProductUser> WithProducts(IQueryable<ProductUser> entities)
        {
            return
                entities
                    .Include(x => x.Product);
        }
    }
}
