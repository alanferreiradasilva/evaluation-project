using MediatR;
using NetCore.Ambev.Abstractions.Entities;

namespace NetCore.Ambev.Application.Carts.Commands
{
    public sealed class CreateCartCommand : IRequest<Cart>
    {
        public IEnumerable<CartProduct> Products { get; set; }
    }
}
