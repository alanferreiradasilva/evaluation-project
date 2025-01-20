using MediatR;
using NetCore.Ambev.Abstractions.Entities;

namespace NetCore.Ambev.Application.Carts.Commands.Notifications
{
    public class CartCreatedNotification : INotification
    {
        public Cart Cart { get; }

        public CartCreatedNotification(Cart cart)
        {
            Cart = cart;
        }
    }
}
