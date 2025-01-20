using MongoDB.Driver;
using NetCore.Ambev.Abstractions.Entities;
using NetCore.Ambev.Abstractions.Repositories;

namespace NetCore.Ambev.Infra.Repositories
{
    public abstract class BaseNoSqlRepository<T> : IBaseNoSqlRepository<T> where T : BaseEntity
    {
        protected readonly IMongoCollection<T> _collection;

        protected BaseNoSqlRepository(IMongoClient mongoClient)
        {
            string databaseName = "mongodb://localhost:27017/";
            var database = mongoClient.GetDatabase(databaseName);
            _collection = database.GetCollection<T>(typeof(T).Name);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public Task<T> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
            //return await _collection.Find(x => x.GetPropertyValue<string>("Id") == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
            //await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("Id", entity.GetPropertyValue<string>("Id")), entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("Id", id));
        }
    }
}
