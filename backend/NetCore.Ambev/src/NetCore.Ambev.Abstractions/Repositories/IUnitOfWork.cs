using NetCore.Ambev.Abstractions.Repositories.NoSql;

namespace NetCore.Ambev.Abstractions.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IProductRepository ProductRepository { get; }
        ICartRepository CartRepository { get; }
        ICartNoSqlRepository CartNoSqlRepository { get; }

        Task CommitAsync();
    }
}
