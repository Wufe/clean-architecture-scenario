using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Repositories.Common
{
    public interface IRepository<TEntity> : IReadRepository<TEntity>, IWriteRepository<TEntity>
        where TEntity : class
    {
    }
}
