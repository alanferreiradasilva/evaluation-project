using NetCore.Ambev.Abstractions.Entities;

namespace NetCore.Ambev.Abstractions.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T> FindAsync(int id);
        Task<T> AddAsync(T entity);
        void UpdateAsync(T entity);
        Task<T> DeleteAsync(int id);
    }
}
