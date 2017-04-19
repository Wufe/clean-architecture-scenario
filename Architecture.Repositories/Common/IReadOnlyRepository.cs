using Architecture.Models.Interfaces;
using System.Linq;

namespace Architecture.Repositories.Common
{
    public interface IReadOnlyRepository<T>
        where T: class, IEntity
    {
        IQueryable<T> GetAll();

        T GetById(int id);
    }
}
