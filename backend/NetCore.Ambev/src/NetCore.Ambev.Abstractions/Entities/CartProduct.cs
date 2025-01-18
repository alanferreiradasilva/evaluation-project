namespace NetCore.Ambev.Abstractions.Entities
{
    public class CartProduct : BaseEntity
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
