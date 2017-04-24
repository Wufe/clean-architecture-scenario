using Architecture.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Repositories.Common
{
    public interface IWriteRepository<TEntity>
    {
        TEntity Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);

        void Save();

        TEntity Attach(ref TEntity entity, Func<TEntity, bool> entityPredicate);
    }
}
