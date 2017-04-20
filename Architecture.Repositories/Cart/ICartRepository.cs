using Architecture.Repositories.Common;
using System.Linq;

namespace Architecture.Repositories.Cart
{
    public interface ICartRepository : IRepository<Database.Entities.Cart>
    {
        IQueryable<Database.Entities.Cart> WithProducts(IQueryable<Database.Entities.Cart> entities);
    }
}
