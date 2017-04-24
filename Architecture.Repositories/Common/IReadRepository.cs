using Architecture.Models.Interfaces;
using System;
using System.Linq;

namespace Architecture.Repositories.Common
{
    public interface IReadRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();
    }
}
