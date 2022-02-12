using HMS.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, params string[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            if(includes != null && includes.Length > 0)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            return await query.Where(filter).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllPagenatedAsync(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> filter = null, params string[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            if(includes != null && includes.Length > 0)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            return await query.Where(filter).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null, params string[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            if (includes != null && includes.Length > 0)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            return await query.FirstOrDefaultAsync(filter);
        }

        public async Task<int> GetTotalCountAsync(Expression<Func<TEntity, bool>> filter = null, params string[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            if(includes != null && includes.Length > 0)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            return await query.CountAsync(filter);
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);    
        }

        public async Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> filter, params string[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            if(includes != null && includes.Length > 0)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            return await query.AnyAsync(filter);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
    }
}
