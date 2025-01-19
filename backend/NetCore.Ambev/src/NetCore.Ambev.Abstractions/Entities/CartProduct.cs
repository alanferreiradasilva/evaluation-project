namespace NetCore.Ambev.Abstractions.Entities
{
    public class CartProduct : BaseEntity
    {
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }
    }
}
