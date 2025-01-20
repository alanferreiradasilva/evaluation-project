using MediatR;
using NetCore.Ambev.Application.Dtos;

namespace NetCore.Ambev.Application.Carts.Commands
{
    public sealed class CreateCartCommand : IRequest<CartDto>
    {
        public IEnumerable<CartProductDto> Products { get; set; }
    }
}
