namespace NetCore.Ambev.Abstractions.Repositories
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        ICartRepository CartRepository { get; }

        Task CommitAsync();
    }
}
