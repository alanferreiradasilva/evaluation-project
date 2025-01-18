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

            return new Product
            {
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                Price = faker.Random.Decimal(0, 1000),
                Image = faker.Image.PicsumUrl(),
                Rate = faker.Random.Number(0, 5),
                RateCount = faker.Random.Number(0, 1000),
                Category = faker.Random.ListItem(categories)
            };
        }

        public static IEnumerable<Product> Seed()
        {
            return Enumerable.Range(1, 10)
                .Select(i => GetFakeProduct())
                .ToList();
        }
    }
}
