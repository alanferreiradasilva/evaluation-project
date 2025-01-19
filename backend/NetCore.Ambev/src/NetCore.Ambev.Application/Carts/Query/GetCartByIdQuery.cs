using MediatR;
using NetCore.Ambev.Abstractions.Entities;
using NetCore.Ambev.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Ambev.Application.Carts.Query
{
    public class GetCartByIdQuery : IRequest<Cart>
    {
        public int Id { get; set; }

        public class GetCartsByIdQueryHandler : IRequestHandler<GetCartByIdQuery, Cart>
        {
            private readonly ICartRepository _cartRepository;

            public GetCartsByIdQueryHandler(ICartRepository cartRepository)
            {
                _cartRepository = cartRepository;
            }

            public async Task<Cart> Handle(GetCartByIdQuery request, CancellationToken cancellationToken)
            {
                var entity = await _cartRepository.FindAsync(request.Id);
                return entity;
            }
        }
    }
}
