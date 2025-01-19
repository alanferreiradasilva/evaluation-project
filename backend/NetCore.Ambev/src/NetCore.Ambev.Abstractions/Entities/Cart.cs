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

            UserId = userId;
            Date = DateTime.UtcNow;
        }
    }
}
