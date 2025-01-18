using NetCore.Ambev.Abstractions.Entities.Validations;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;

namespace NetCore.Ambev.Abstractions.Entities
{
    public class Cart : BaseEntity
    {
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<CartProduct> Products { get; set; }

        public Cart() {}

        public Cart(int userId, IEnumerable<CartProduct> products) 
        { 
            ValidateDomain(userId, products);
        }

        private void ValidateDomain(int userId, IEnumerable<CartProduct> products, bool newDate = false)
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
