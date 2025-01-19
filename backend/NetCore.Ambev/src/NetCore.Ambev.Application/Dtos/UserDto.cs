using Mapster;
using NetCore.Ambev.Abstractions.Entities;

namespace NetCore.Ambev.Application.Dtos
{
    public class UserDto
    {
        public string Email { get; set; }
        public string Username { get; set; }        
        public string Phone { get; set; }

        public UserNameDto Name { get; set; }
        public UserAddressDto Address { get; set; }
        public UserGeolocationDto Geolocation { get; set; }

        public UserStatus Status { get; set; }
        public UserRole Role { get; set; }
    }

    public class UserNameDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }

    public class UserAddressDto
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Zipcode { get; set; }
    }

    public class UserGeolocationDto
    {
        public string? Lat { get; set; }
        public string? Long { get; set; }
    }
}
