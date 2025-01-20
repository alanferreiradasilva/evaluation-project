using MongoDB.Driver;
using NetCore.Ambev.Abstractions.Entities;
using NetCore.Ambev.Abstractions.Repositories.NoSql;

namespace NetCore.Ambev.Infra.Repositories.NoSql
{
    public class CartNoSqlRepository : BaseNoSqlRepository<Cart>, ICartNoSqlRepository
    {
        public CartNoSqlRepository(IMongoClient client) :base(client)
        {
            
        }
    }
}
