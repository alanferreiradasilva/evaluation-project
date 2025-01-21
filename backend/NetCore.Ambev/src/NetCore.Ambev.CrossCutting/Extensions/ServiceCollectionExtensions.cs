using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using NetCore.Ambev.Abstractions.Repositories;
using NetCore.Ambev.Abstractions.Repositories.NoSql;
using NetCore.Ambev.Application.Carts.Commands.Validations;
using NetCore.Ambev.Infra.Context;
using NetCore.Ambev.Infra.Repositories;
using NetCore.Ambev.Infra.Repositories.NoSql;
using NetCore.Ambev.Infra.Settings;
using Npgsql;
using System.Data;
using System.Reflection;

namespace NetCore.Ambev.CrossCutting.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomInfrastructure(
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

            services.AddMongoDB();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICartRepository, CartRepository>();            

            services.AddScoped<INoSqlUnitOfWork, NoSqlUnitOfWork>();
            services.AddScoped<ICartNoSqlRepository, CartNoSqlRepository>();
            services.AddScoped<IUserNoSqlRepository, UserNoSqlRepository>();

            string assemblyApplicationName = "NetCore.Ambev.Application";

            var handler = AppDomain.CurrentDomain.Load(assemblyApplicationName);

            services.AddMediatR(x => {
                x.RegisterServicesFromAssembly(handler);
                x.AddOpenBehavior(typeof(ValidationBehaviour<,>));
            });

            services.AddValidatorsFromAssembly(Assembly.Load(assemblyApplicationName));

            return services;
        }

        private static void AddMongoDB(this IServiceCollection services)
        {
            services.AddScoped<IMongoClient>(sp =>
            {
                var connectionString = EnvironmentSettings.DefaultMongoConnection;
                return new MongoClient(connectionString);
            });
        }
    }
}
