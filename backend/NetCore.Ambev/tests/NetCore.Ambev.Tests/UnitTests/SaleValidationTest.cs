using NetCore.Ambev.Abstractions.Entities;
using Shouldly;

namespace NetCore.Ambev.Tests.UnitTests
{
    public class SaleValidationTest
    {
        [Fact]
        public void ValidatePurchasesAboveFourIdenticalItems()
        {
            var products = Enumerable.Range(1, 9)
                                .Select(x => 
                                    new Product(1, "Test", 100, "Lorem", "Electronic", "http://test.com", 5, 10)
                                 );

            var sale = new Sale(10, products.Sum(x => x.Price), 10, 10, 100, products);

            sale.TotalAmountForEachItem.ShouldBe(810);
        }

        [Fact]
        public void ValidatePurchasesBetweenTenAndTwentyIdenticalItems()
        {
            var products = Enumerable.Range(1, 20)
                                .Select(x =>
                                    new Product(1, "Test", 100, "Lorem", "Electronic", "http://test.com", 5, 10)
                                 );

            var sale = new Sale(10, products.Sum(x => x.Price), 10, 10, 100, products);

            sale.TotalAmountForEachItem.ShouldBe(1600);
        }
    }
}
