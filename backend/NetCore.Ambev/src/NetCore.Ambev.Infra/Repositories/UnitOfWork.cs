using NetCore.Ambev.Abstractions.Repositories;
using NetCore.Ambev.Infra.Context;

namespace NetCore.Ambev.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IProductRepository? _productRepository;
        private ICartRepository? _cartRepository;

        private readonly AmbevDbContext _context;

        public UnitOfWork(AmbevDbContext context)
        {
            _context = context;
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
