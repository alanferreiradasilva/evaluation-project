namespace NetCore.Ambev.Abstractions.Entities
{
    public class CartProduct : BaseEntity
    {        
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }
        public int CartId { get; private set; }
        
        public Cart Cart { get; set; }
        public Product Product { get; set; }


        public CartProduct() {}

        public CartProduct(int cartId, int productId, int quantity)
        {
            CartId = cartId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
