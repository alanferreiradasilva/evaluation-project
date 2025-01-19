﻿using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NetCore.Ambev.Abstractions.Repositories;
using NetCore.Ambev.Application.Carts.Commands.Validations;
using NetCore.Ambev.Infra.Context;
using NetCore.Ambev.Infra.Repositories;
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

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            string assemblyApplicationName = "NetCore.Ambev.Application";

            var handler = AppDomain.CurrentDomain.Load(assemblyApplicationName);

            services.AddMediatR(x => {
                x.RegisterServicesFromAssembly(handler);
                x.AddOpenBehavior(typeof(ValidationBehaviour<,>));
            });

            services.AddValidatorsFromAssembly(Assembly.Load(assemblyApplicationName));

            return services;
        }
    }
}
