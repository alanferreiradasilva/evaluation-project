using NetCore.Ambev.Abstractions.Entities;
using NetCore.Ambev.Abstractions.Entities.Paging;
using System.Linq.Expressions;

namespace NetCore.Ambev.Abstractions.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T> FindAsync(int id);
        Task<T> AddAsync(T entity);
        void UpdateAsync(T entity);
        Task<T> DeleteAsync(int id);

        Task<PagedList<T>> GetListAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? page = null,
            int? pageSize = null);
    }
}
