using Architecture.Models.Interfaces;
using Architecture.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Architecture.Repositories.EntityFramework.Common
{
    public class EFIndexedRepository<TEntity> : EFRepository<TEntity>, IIndexedRepository<TEntity>
        where TEntity: class, IEntity
    {
        public EFIndexedRepository(DbContext context) : base(context)
        {
        }

        public TEntity GetById(int id)
        {
            return
                GetAll()
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }
    }
}
