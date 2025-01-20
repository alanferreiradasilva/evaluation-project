using MediatR;
using Microsoft.Extensions.Logging;
using NetCore.Ambev.Abstractions.Repositories;

namespace NetCore.Ambev.Application.Carts.Commands.Notifications
{
    public class CartCreatedDataHandler : INotificationHandler<CartCreatedNotification>
    {
        private readonly ILogger<CartCreatedDataHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public CartCreatedDataHandler(ILogger<CartCreatedDataHandler> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CartCreatedNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"New Cart created: {notification.Cart.Id} at {notification.Cart.Date.ToString("ddMMyyyy HH:mm:ss")}.");

            await _unitOfWork.CartNoSqlRepository.CreateAsync(notification.Cart);
        }
    }
}
