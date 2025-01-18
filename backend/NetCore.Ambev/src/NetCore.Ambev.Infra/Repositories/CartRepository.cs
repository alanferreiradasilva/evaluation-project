using NetCore.Ambev.Abstractions.Entities;
using NetCore.Ambev.Abstractions.Repositories;
using NetCore.Ambev.Infra.Context;

namespace NetCore.Ambev.Infra.Repositories
{
    public class CartRepository : BaseRepository<Cart>, ICartRepository
    {
        public CartRepository(AmbevDbContext context) : base(context)
        {

        }
    }
}
