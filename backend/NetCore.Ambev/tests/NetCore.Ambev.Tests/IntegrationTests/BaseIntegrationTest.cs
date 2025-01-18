using Microsoft.EntityFrameworkCore;
using NetCore.Ambev.Infra.Context;
using NetCore.Ambev.Infra.Settings;

namespace NetCore.Ambev.Tests.IntegrationTests
{
    public abstract class BaseIntegrationTest
    {
        protected DbContextOptions<AmbevDbContext> baseOptions;
        protected readonly string ConnectionString;

        protected BaseIntegrationTest()
        {
            ConnectionString = EnvironmentSettings.DefaultTestConnection;
        }
    }
}
