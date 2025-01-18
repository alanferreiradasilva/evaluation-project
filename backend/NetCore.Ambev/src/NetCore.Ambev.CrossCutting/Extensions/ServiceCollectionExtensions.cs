using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NetCore.Ambev.Infra.Context;
using NetCore.Ambev.Infra.Settings;
using Npgsql;
using System.Data;

namespace NetCore.Ambev.CrossCutting.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(
                  this IServiceCollection services)
        {
            string defaultConnection = EnvironmentSettings.DefaultConnection;

            services.AddDbContext<AmbevDbContext>(options => {
                options.UseNpgsql(defaultConnection);
            });

            services.AddSingleton<IDbConnection>(provider =>
            {
                var connection = new NpgsqlConnection(defaultConnection);
                connection.Open();
                return connection;
            });

            return services;
        }
    }
}
