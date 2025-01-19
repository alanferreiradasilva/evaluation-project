namespace NetCore.Ambev.Application.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }

        public ProductRatingDto Rating { get; set; }
    }

    public class ProductRatingDto
    {
        public decimal Rate { get; set; }
        public int RateCount { get; set; }
    }
}
