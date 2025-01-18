using Microsoft.EntityFrameworkCore;
using NetCore.Ambev.Abstractions.Entities;
using NetCore.Ambev.Abstractions.Repositories;

namespace NetCore.Ambev.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                return null;
            }

            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> FindAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async void UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
