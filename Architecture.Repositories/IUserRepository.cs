using Architecture.Database.Entities;
using Architecture.Repositories.Common;

namespace Architecture.Repositories
{
    public interface IUserRepository : IIndexedRepository<User>
    {
    }
}
