using EVideoPrime.API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EVideoPrime.API.Repository.Services
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dBContext;

        public Repository(DbContext dBContext)
        {
            _dBContext = dBContext;
        }

        #region Fetching Data
        public async Task<TEntity?> GetAsync(dynamic id)
        {
            var data = await _dBContext.Set<TEntity>().FindAsync(id);
            return data;
        }

        public async Task<IEnumerable<TEntity>?> GetAllAsync()
        {
            var data = _dBContext.Set<TEntity>().ToList();
            return await Task.FromResult(data);
        }

        public async Task<IEnumerable<TEntity>?> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var data = _dBContext.Set<TEntity>().Where(predicate);
            return await Task.FromResult(data);
        }
        #endregion

        #region Creating new data
        public async Task<TEntity?> AddAsync(TEntity model)
        {
            dynamic data = await _dBContext.Set<TEntity>().AddAsync(model);
            return data;
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> model)
        {
            await _dBContext.Set<TEntity>().AddRangeAsync(model);
        }
        #endregion

        #region Removing data
        public async Task<TEntity?> RemoveAsync(TEntity model)
        {
            dynamic data = _dBContext.Set<TEntity>().Remove(model);
            return await Task.FromResult<TEntity>(data);
        }

        public async Task RemoveRangeAsync(IEnumerable<TEntity> model)
        {
            _dBContext.Set<TEntity>().RemoveRange(model);
            await Task.CompletedTask;
        }
        #endregion
    }
}
