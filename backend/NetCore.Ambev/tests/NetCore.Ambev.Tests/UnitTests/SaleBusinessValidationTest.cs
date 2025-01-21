using NetCore.Ambev.Abstractions.Entities;
using Shouldly;

namespace NetCore.Ambev.Tests.UnitTests
{
    public class SaleBusinessValidationTest
    {
        private Product GetProduct()
            => new Product(1, "Test", 100, "Lorem", "Electronic", "http://test.com", 5, 10);

        [Fact]
        public void ValidatePurchasesAboveFourIdenticalItems()
        {
            var products = Enumerable.Range(1, 9).Select(x => GetProduct());

            var sale = new Sale(10, products.Sum(x => x.Price), 10, 10, 100, products);

            sale.TotalAmountForEachItem.ShouldBe(810);
            sale.Discount.ShouldBe(10);
        }

        [Fact]
        public void ValidatePurchasesBetweenTenAndTwentyIdenticalItems()
        {
            var products = Enumerable.Range(1, 20).Select(x => GetProduct());

            var sale = new Sale(10, products.Sum(x => x.Price), 10, 10, 100, products);

            sale.TotalAmountForEachItem.ShouldBe(1600);
            sale.Discount.ShouldBe(20);
        }

        [Fact]
        public void ValidatePurchasesLessThanFourProducts()
        {
            var products = Enumerable.Range(1, 4).Select(x => GetProduct());

            var sale = new Sale(10, products.Sum(x => x.Price), 10, 10, 100, products);

            sale.TotalAmountForEachItem.ShouldBe(400);
            sale.Discount.ShouldBe(decimal.Zero);
        }


    }
}
