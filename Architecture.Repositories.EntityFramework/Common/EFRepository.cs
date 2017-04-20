using Architecture.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Architecture.Models.Interfaces;

namespace Architecture.Repositories.EntityFramework.Common
{
    public abstract class EFRepository<T> : IRepository<T>
        where T: class, IEntity
    {
        protected readonly DbContext _context;

        public EFRepository(DbContext context)
        {
            _context = context;
            Console.WriteLine($"####\n Context Hash{context.GetHashCode()}\n####");
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetById(int id)
        {
            return
                GetAll()
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
        }
    }
}
