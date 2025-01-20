using NetCore.Ambev.Abstractions.Entities.Validations;

namespace NetCore.Ambev.Abstractions.Entities
{
    public class Cart : BaseEntity
    {
        public int UserId { get;private set; }
        public DateTime Date { get;private set; }
        public IEnumerable<CartProduct> Products { get;private set; }

        public Cart() {}

        public Cart(int userId, IEnumerable<CartProduct> products) 
        { 
            ValidateDomain(userId, products);
        }

        private void ValidateDomain(int userId, IEnumerable<CartProduct> products)
        {
            DomainValidation.When(userId <= 0,
                "Invalid User Id.");

            DomainValidation.When(products.Count() == 0,
                "Invalid Product List. Cart must be almost one product.");

            DomainValidation.When(products.Any(x => x.ProductId == 0), "Invalid product. Product Id must be valid.");
            DomainValidation.When(products.Any(x => x.Quantity == 0), "Invalid product quantity. Product quantity must be 1 or greater.");

            UserId = userId;
            Date = DateTime.UtcNow;
            Products = products;
        }
    }
}
