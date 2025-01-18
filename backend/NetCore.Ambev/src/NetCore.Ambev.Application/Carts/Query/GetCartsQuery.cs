using MediatR;
using NetCore.Ambev.Abstractions.Entities;
using NetCore.Ambev.Abstractions.Repositories;

namespace NetCore.Ambev.Application.Carts.Query
{
    public class GetCartsQuery : IRequest<IEnumerable<Cart>>
    {
        public class GetCartsQueryHandler : IRequestHandler<GetCartsQuery, IEnumerable<Cart>>
        {
            private readonly ICartRepository _cartRepository;

            public GetCartsQueryHandler(ICartRepository cartRepository)
            {
                _cartRepository = cartRepository;
            }

            public async Task<IEnumerable<Cart>> Handle(GetCartsQuery request, CancellationToken cancellationToken)
            {
                var Carts = await _cartRepository.GetAsync();
                return Carts;
            }
        }
    }
}
