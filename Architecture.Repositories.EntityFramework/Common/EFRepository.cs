using Architecture.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Architecture.Repositories.EntityFramework.Common
{
    public abstract class EFRepository<T> : IRepository<T>
        where T: class
    {
        protected readonly DbContext _context;

        public EFRepository(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds an entity to the set.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        /// <summary>
        /// Gets all the entities of the set.
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        /// <summary>
        /// Remove an entity from the set.
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        /// <summary>
        /// Calls a SaveChanges on the context.
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Marks an entity as Modified.
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Checks if an entity has been already attached.
        /// If so, does nothing, else attaches it.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entityPredicate"></param>
        /// <returns></returns>
        public T Attach(ref T entity, Func<T, bool> entityPredicate)
        {
            var set = _context.Set<T>();
            T attachedEntity =
                set
                    .Local
                    .SingleOrDefault(entityPredicate);
            if (attachedEntity == null)
            {
                set.Attach(entity);
                return entity;
            }
            else
            {
                entity = attachedEntity;
                return attachedEntity;
            }
        }
    }
}
