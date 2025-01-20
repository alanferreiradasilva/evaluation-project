using MongoDB.Driver;
using NetCore.Ambev.Abstractions.Repositories;
using NetCore.Ambev.Abstractions.Repositories.NoSql;
using NetCore.Ambev.Infra.Context;

namespace NetCore.Ambev.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IUserRepository? _userRepository;
        private IProductRepository? _productRepository;
        
        private ICartRepository? _cartRepository;
        private ICartNoSqlRepository? _cartNoSqlRepository;

        private readonly AmbevDbContext _context;
        private readonly IMongoClient _mongoClient;

        public UnitOfWork(AmbevDbContext context, IMongoClient mongoClient)
        {
            _context = context;
            _mongoClient = mongoClient;
        }

        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository = _userRepository ??
                    new Repositories.UserRepository(_context);
            }
        }
        public IProductRepository ProductRepository
        {
            get
            {
                return _productRepository = _productRepository ??
                    new Repositories.ProductRepository(_context);
            }
        }

        public ICartRepository CartRepository
        {
            get
            {
                return _cartRepository = _cartRepository ??
                    new Repositories.CartRepository(_context);
            }
        }

        public ICartNoSqlRepository CartNoSqlRepository
        {
            get
            {
                return _cartNoSqlRepository = _cartNoSqlRepository ??
                    new Repositories.NoSql.CartNoSqlRepository(_mongoClient);
            }
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
