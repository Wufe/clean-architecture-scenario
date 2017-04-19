using Architecture.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Repositories.Common
{
    public interface IRepository<T> : IReadOnlyRepository<T>
        where T: class, IEntity
    {
        T Add(T entity);

        void Update(T entity);

        void Remove(T entity);

        void Save();
    }
}
