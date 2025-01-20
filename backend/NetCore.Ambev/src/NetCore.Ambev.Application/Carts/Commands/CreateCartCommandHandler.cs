using FluentValidation;
using Mapster;
using MediatR;
using NetCore.Ambev.Abstractions.Entities;
using NetCore.Ambev.Abstractions.Repositories;
using NetCore.Ambev.Application.Carts.Commands.Notifications;
using NetCore.Ambev.Application.Dtos;

namespace NetCore.Ambev.Application.Carts.Commands
{
    public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, CartDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public CreateCartCommandHandler(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<CartDto> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            //_validator.ValidateAndThrow(request);

            var guestUserId = 3;
            var products = request.Products.Adapt<List<CartProduct>>();
            var entity = new Cart(guestUserId, products);

            //await _unitOfWork.CartRepository.AddAsync(entity);
            //await _unitOfWork.CommitAsync();

            await _mediator.Publish(new CartCreatedNotification(entity));

            return entity.Adapt<CartDto>();
        }
    }
}
