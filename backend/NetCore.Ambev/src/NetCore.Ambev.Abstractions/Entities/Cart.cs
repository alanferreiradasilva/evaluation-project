namespace NetCore.Ambev.Abstractions.Entities
{
    public class Cart : BaseEntity
    {
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<CartProduct> Products { get; set; }
    }
}
