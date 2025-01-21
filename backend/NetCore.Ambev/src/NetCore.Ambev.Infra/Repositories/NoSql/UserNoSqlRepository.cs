using MongoDB.Driver;
using NetCore.Ambev.Abstractions.Entities;
using NetCore.Ambev.Abstractions.Repositories.NoSql;

namespace NetCore.Ambev.Infra.Repositories.NoSql
{
    public class UserNoSqlRepository : BaseNoSqlRepository<User>, IUserNoSqlRepository
    {
        public UserNoSqlRepository(IMongoClient client):base(client)
        {
            
        }
    }
}
