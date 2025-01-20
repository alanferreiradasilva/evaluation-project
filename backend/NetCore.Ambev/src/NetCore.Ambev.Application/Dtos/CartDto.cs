namespace NetCore.Ambev.Application.Dtos
{
    public class CartDto
    {
        public int Id { get;set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }

        public CartProductDto Products { get; set; }
    }

    public class CartProductDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
