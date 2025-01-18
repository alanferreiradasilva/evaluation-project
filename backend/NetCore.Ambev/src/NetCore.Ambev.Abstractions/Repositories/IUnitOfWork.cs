namespace NetCore.Ambev.Abstractions.Repositories
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        Task CommitAsync();
    }
}
