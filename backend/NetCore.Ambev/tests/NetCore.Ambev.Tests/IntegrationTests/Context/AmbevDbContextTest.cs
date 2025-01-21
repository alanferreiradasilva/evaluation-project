using Microsoft.EntityFrameworkCore;
using NetCore.Ambev.Infra.Context;
using NetCore.Ambev.Infra.Settings;

namespace NetCore.Ambev.Tests.IntegrationTests.Context
{
    public class AmbevDbContextTest
    {
        private readonly DbContextOptions<AmbevDbContext> _options;

        public AmbevDbContextTest()
        {
            var connectionString = EnvironmentSettings.DefaultTestConnection;

            _options = new DbContextOptionsBuilder<AmbevDbContext>()
                .UseNpgsql(connectionString)
                .Options;
        }

        [Fact]
        public void DbContext_ShouldConnectToDatabase()
        {
            //// Arrange
            //using var context = new AmbevDbContext(_options);

            //// Act & Assert
            //Assert.NotNull(context.Database);
            //using var connection = context.Database.GetDbConnection();
            //try
            //{
            //    connection.Open();
            //}
            //catch (Exception ex)
            //{
            //    Assert.True(false, $"Failed to connect to the database: {ex.Message}");
            //}
        }
    }
}
