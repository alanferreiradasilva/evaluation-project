using FluentValidation;
using MediatR;
using NetCore.Ambev.Abstractions.Entities;
using NetCore.Ambev.Abstractions.Repositories;

namespace NetCore.Ambev.Application.Carts.Commands
{
    public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, Cart>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCartCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Cart> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            //_validator.ValidateAndThrow(request);

            var guestUserId = 3;
            var entity = new Cart(guestUserId, request.Products);

            //await _unitOfWork.CartRepository.AddAsync(entity);
            //await _unitOfWork.CommitAsync();

            return entity;
        }
    }
}
