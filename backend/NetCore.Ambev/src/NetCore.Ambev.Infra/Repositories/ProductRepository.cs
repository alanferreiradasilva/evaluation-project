using NetCore.Ambev.Abstractions.Entities;
using NetCore.Ambev.Abstractions.Repositories;
using NetCore.Ambev.Infra.Context;

namespace NetCore.Ambev.Infra.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(AmbevDbContext context) :base(context)
        {
            
        }
    }
}
