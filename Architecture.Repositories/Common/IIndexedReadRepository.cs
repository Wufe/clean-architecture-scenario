using Architecture.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Architecture.Repositories.Common
{
    public interface IIndexedReadRepository<TEntity>
        where TEntity : class, IEntity
    {
        TEntity GetById(int id);
    }
}
