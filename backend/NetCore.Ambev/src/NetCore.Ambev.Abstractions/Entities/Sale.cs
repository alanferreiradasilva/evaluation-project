using NetCore.Ambev.Abstractions.Entities.Validations;
using System.Security.Principal;

namespace NetCore.Ambev.Abstractions.Entities
{
    public class Sale : BaseEntity
    {
        /* Sale number
        * Date when the sale was made
        * Customer
        * Total sale amount
        * Branch where the sale was made
        * CartProducts
        * Quantities
        * Unit prices
        * Discounts
        * Total amount for each item
        * Cancelled/Not Cancelled*/
        public DateTime Date { get; private set; }
        public int Customer { get; private set; }
        public decimal TotalSaleAmount { get; private set; }
        public int SalesBranch { get; private set; }
        public int Quantities { get; private set; }
        public decimal UnitPrices { get; private set; }
        public decimal Discount { get; private set; }
        public decimal TotalAmountForEachItem { get; private set; }
        public SaleState State { get; private set; }

        public IEnumerable<Product> Products { get; private set; }

        public Sale(int customer, decimal totalSaleAmount, int salesBranch, int quantities, decimal unitPrices, IEnumerable<Product> products) 
        {
            ValidateDomain(products);

            Customer = customer;
            TotalSaleAmount  = totalSaleAmount;
            SalesBranch = salesBranch;
            Quantities = quantities;
            UnitPrices = unitPrices;
            Products = products;
            
            var groupedProducts = Products.GroupBy(x => x.Id);

            if (groupedProducts.Any(g => g.Count() > 4 && g.Count() < 10))
            {
                //Purchases above 4 identical items have a 10% discount

                ValidatePurchasesAboveFourIdenticalItems(products);
            }
            else if (groupedProducts.Any(g => g.Count() >= 10 && g.Count() <= 20))
            {
                //Purchases between 10 and 20 identical items
                ValidatePurchasesBetweenTenAndTwentyIdenticalItems(products);
            }
            else
            {
                ApplyDiscount(products, 0);
            }
        }

        public Sale() { }

        public Sale(int id) { }

        private void ValidateDomain(IEnumerable<Product> products)
        {
            DomainValidation.When(products is null || !products.Any(),
                "Invalid products list. Sale mut be have almost one product.");

            DomainValidation.When(products.Count() > 20,
                "Invalid products list. Sale mut be have maximun 20 products.");
        }

        private void ValidatePurchasesAboveFourIdenticalItems(IEnumerable<Product> products)
        {
            ApplyDiscount(products, 10);
        }

        private void ValidatePurchasesBetweenTenAndTwentyIdenticalItems(IEnumerable<Product> products)
        {
            ApplyDiscount(products, 20);
        }

        private void ApplyDiscount(IEnumerable<Product> products, decimal discount)
        {
            Discount = discount;
            decimal totalSum = products.Sum(x => x.Price);
            TotalAmountForEachItem = totalSum - (totalSum / 100 * Discount);
        }
    }
}
