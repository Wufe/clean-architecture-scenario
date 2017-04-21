using Architecture.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Repositories.Common
{
    public interface IIndexedRepository<TEntity> : IReadRepository<TEntity>, IIndexedReadRepository<TEntity>, IWriteRepository<TEntity>
        where TEntity : class, IEntity
    {
    }
}
