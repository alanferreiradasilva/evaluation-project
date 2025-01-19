using Mapster;
using Microsoft.Extensions.DependencyInjection;
using NetCore.Ambev.Abstractions.Entities;
using NetCore.Ambev.Application.Dtos;
using System.Reflection;

namespace NetCore.Ambev.CrossCutting.Extensions
{
    public static class MapperConfiguration
    {
        public static void RegisterCustomMaps(this IServiceCollection services)
        {
            RegisterUserMap();
            RegisterProductMap();

            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        }

        private static void RegisterUserMap()
        {
            TypeAdapterConfig<User, UserDto>
                .NewConfig()
                .Map(dest => dest.Name, src => new UserNameDto
                {
                    Firstname = src.Firstname,
                    Lastname = src.Lastname
                })
                .Map(dest => dest.Address, src => new UserAddressDto
                {
                    City = src.City,
                    Street = src.Street,
                    Number = src.Number,
                    Zipcode = src.Zipcode
                })
                .Map(dest => dest.Geolocation, src => new UserGeolocationDto
                {
                    Lat = src.Lat,
                    Long = src.Long
                });
        }

        private static void RegisterProductMap()
        {
            TypeAdapterConfig<Product, ProductDto>
                .NewConfig()
                .Map(dest => dest.Rating, src => new ProductRatingDto
                {
                    Rate = src.Rate,
                    RateCount = src.RateCount
                });
        }
    }
}
