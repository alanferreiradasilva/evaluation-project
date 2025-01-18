using Microsoft.EntityFrameworkCore;
using NetCore.Ambev.Infra.Context;
using NetCore.Ambev.Infra.Settings;
using NetCore.Ambev.Tests.IntegrationTests.Seeds;

namespace NetCore.Ambev.Tests.IntegrationTests
{
    public class ProductIntegrationTest : BaseIntegrationTest
    {
        public ProductIntegrationTest():base()
        {
            baseOptions = new DbContextOptionsBuilder<AmbevDbContext>()
                .UseNpgsql(ConnectionString)
                .UseSeeding((context, _) =>
                {
                    context.Products.AddRange(ProductSeed.Seed());
                    context.SaveChanges();
                })
                .Options;

            using (var context = new AmbevDbContext(baseOptions))
            {
                context.Database.Migrate(); // Aplica as migrations antes de cada teste
            }
        }

        [Fact]
        public void MustToHaveTenProducts()
        {
            // Arrange
            using (var context = new AmbevDbContext(baseOptions))
            {
                // Act 
                var productCount = context.Products.Count();

                // Assert
                Assert.Equal(10, productCount);
            }
        }
    }
}
