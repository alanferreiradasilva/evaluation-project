using NetCore.Ambev.Abstractions.Entities;
using NetCore.Ambev.Abstractions.Entities.Validations;
using Shouldly;

namespace NetCore.Ambev.Tests.UnitTests
{
    public class SaleDomainValidationTest
    {
        private Product GetProduct()
            => new Product(1, "Test", 100, "Lorem", "Electronic", "http://test.com", 5, 10);

        [Fact]
        public void ValidateMaximunOfTwentyProducs()
        {
            var products = Enumerable.Range(1, 21).Select(x => GetProduct());

            Should.Throw<DomainValidation>(() =>
            {
                var sale = new Sale(10, products.Sum(x => x.Price), 10, 10, 100, products);
            });
        }

        [Fact]
        public void ValidateMaximunWithNullProductList()
        {
            IEnumerable<Product> products = default(IEnumerable<Product>);
            decimal sumPrices = products is not null ? products.Sum(x => x.Price) : decimal.Zero;

            Should.Throw<DomainValidation>(() =>
            {
                var sale = new Sale(10, sumPrices, 10, 10, 100, products);
            });
        }

        [Fact]
        public void ValidateMaximunWithEmptyProductList()
        {
            IEnumerable<Product> products = Enumerable.Empty<Product>();

            Should.Throw<DomainValidation>(() =>
            {
                var sale = new Sale(10, products.Sum(x => x.Price), 10, 10, 100, products);
            });
        }
    }
}
