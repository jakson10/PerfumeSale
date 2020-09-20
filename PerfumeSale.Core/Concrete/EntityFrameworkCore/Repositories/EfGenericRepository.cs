using PerfumeSale.Core.Abstract;
using PerfumeSale.Core.Concrete.EntityFrameworkCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace PerfumeSale.Core.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly PsDatabaseContext _context;
        public EfGenericRepository(PsDatabaseContext context)
        {
            _context = context;
        }

        public async Task<int> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return await Save();
        }

        public async Task<int> Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await Save();
        }

        public async Task<int> Edit(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
            return await Save();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public async Task<T> Get(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public IQueryable<T> Include(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = GetAll();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return includes.Aggregate(query, (current, includesProperty) => current.Include(includesProperty));
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
