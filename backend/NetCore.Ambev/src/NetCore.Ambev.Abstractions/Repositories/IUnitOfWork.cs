namespace NetCore.Ambev.Abstractions.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IProductRepository ProductRepository { get; }
        ICartRepository CartRepository { get; }

        Task CommitAsync();
    }
}
