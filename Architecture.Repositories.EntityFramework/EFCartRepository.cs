using System;
using System.Linq;
using Architecture.Database.Entities;
using Architecture.Repositories.Cart;
using Architecture.Repositories.EntityFramework.Common;
using Microsoft.EntityFrameworkCore;

namespace Architecture.Repositories.EntityFramework
{
    public class EFCartRepository : EFRepository<Database.Entities.Cart>, ICartRepository
    {
        public EFCartRepository(DbContext context) : base(context)
        {
        }

        public IQueryable<Database.Entities.Cart> WithProducts(IQueryable<Database.Entities.Cart> entities)
        {
            return
                entities
                    .Include(x => x.Product);
        }
    }
}
