using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EVideoPrime.API.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //Fetching Data
        Task<TEntity?> GetAsync(dynamic id);
        Task<IEnumerable<TEntity>?> GetAllAsync();
        Task<IEnumerable<TEntity>?> FindAsync(Expression<Func<TEntity, bool>> predicate);

        //Creating Data
        Task<TEntity?> AddAsync(TEntity model);
        Task AddRangeAsync(IEnumerable<TEntity> model);

        //Deleting Data
        Task<TEntity?> RemoveAsync(TEntity model);
        Task RemoveRangeAsync(IEnumerable<TEntity> model);
    }
}
