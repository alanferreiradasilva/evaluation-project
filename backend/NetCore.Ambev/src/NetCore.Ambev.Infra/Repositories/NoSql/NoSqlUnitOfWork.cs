using MongoDB.Driver;
using NetCore.Ambev.Abstractions.Repositories.NoSql;
using NetCore.Ambev.Infra.Context;

namespace NetCore.Ambev.Infra.Repositories.NoSql
{
    public class NoSqlUnitOfWork : INoSqlUnitOfWork, IDisposable
    {        
        private ICartNoSqlRepository? _cartNoSqlRepository;
     
        private readonly IMongoClient _mongoClient;

        public NoSqlUnitOfWork(AmbevDbContext context, IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
        }        

        public ICartNoSqlRepository CartNoSqlRepository
        {
            get
            {
                return _cartNoSqlRepository = _cartNoSqlRepository ??
                    new Repositories.NoSql.CartNoSqlRepository(_mongoClient);
            }
        }

        public void Dispose()
        {
            _mongoClient.Dispose();
        }
    }
}
