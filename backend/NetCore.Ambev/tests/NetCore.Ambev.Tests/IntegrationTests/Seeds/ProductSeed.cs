using Bogus;
using NetCore.Ambev.Abstractions.Entities;

namespace NetCore.Ambev.Tests.IntegrationTests.Seeds
{
    public static class ProductSeed
    {
        private static readonly List<string> categories = 
            new List<string> { "Video Games", "Smartphones", "Gadgets", "Electronics" };
        
        private static Product GetFakeProduct()
        {
            var faker = new Faker();

            return new Product(
                faker.Commerce.ProductName(),
                faker.Random.Decimal(0, 1000),
                faker.Commerce.ProductDescription(),
                faker.Random.ListItem(categories),
                faker.Image.PicsumUrl(),
                faker.Random.Number(0, 5),
                faker.Random.Number(0, 1000)
            );
        }

        public static IEnumerable<Product> Seed()
        {
            return Enumerable.Range(1, 10)
                .Select(i => GetFakeProduct())
                .ToList();
        }
    }
}
