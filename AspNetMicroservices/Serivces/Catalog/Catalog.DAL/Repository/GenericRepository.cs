using Catalog.Entities.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DAL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _entitis;
        public GenericRepository(DbContext context)
        {
            _context = context;
            _entitis = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _context.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entitis.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await _entitis.AsNoTracking().Where(expression).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await _entitis.FindAsync(Id);
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await _entitis.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<T> GetLastOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            List<T> result = await _entitis.AsNoTracking().Where(expression).ToListAsync();
            return result.LastOrDefault();
        }

        public void Remove(T entity)
        {
            _entitis.Remove(entity);
        }

        public async Task RemoveById(int id)
        {
            T itemToDelete = await _entitis.FindAsync(id);
            _entitis.Remove(itemToDelete);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _entitis.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _entitis.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _entitis.UpdateRange(entities);
        }
    }
}
