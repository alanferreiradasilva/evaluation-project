namespace NetCore.Ambev.Abstractions.Repositories.NoSql
{
    public interface INoSqlUnitOfWork
    {
        ICartNoSqlRepository CartNoSqlRepository { get; }
        IUserNoSqlRepository UserNoSqlRepository { get; }
    }
}
