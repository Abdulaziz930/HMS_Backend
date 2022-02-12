using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Core.Repositories
{
    public interface IRepository<TEntity>
    {
        Task InsertAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllPagenatedAsync(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> filter = null, params string[] includes);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, params string[] includes);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null, params string[] includes);
        Task<int> GetTotalCountAsync(Expression<Func<TEntity, bool>> filter = null, params string[] includes);
        Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> filter, params string[] includes);
        void Remove(TEntity entity);
    }
}
