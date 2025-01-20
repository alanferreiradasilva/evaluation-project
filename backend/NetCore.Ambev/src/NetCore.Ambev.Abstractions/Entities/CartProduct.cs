namespace NetCore.Ambev.Abstractions.Entities
{
    public class CartProduct : BaseEntity
    {
        public int CartId { get; private set; }
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }

        public CartProduct() {}

        public CartProduct(int cartId, int productId, int quantity)
        {
            CartId = cartId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
