using NetCore.Ambev.Abstractions.Entities.Validations;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace NetCore.Ambev.Abstractions.Entities
{
    public class User : BaseEntity
    {
        public string Email { get;private set; }
        public string Username { get;private set; }
        public string Password { get;private set; }        
        public string Phone { get;private set; }
        public string Firstname { get;private set; }
        public string Lastname { get;private set; }

        public string City { get;private set; }
        public string Street { get;private set; }
        public int Number { get;private set; }
        public string Zipcode { get;private set; }

        public string? Lat { get;private set; }
        public string? Long { get;private set; }

        public UserStatus Status { get;private set; }
        public UserRole Role { get;private set; }

        public User() { }

        public User(
        string email,
        string username,
        string password,
        string phone,
        string firstname,
        string lastname,
        string city,
        string street,
        int number,
        string zipcode,
        string lat,
        string @long,
        UserStatus status,
        UserRole role
    )
        {
            Email = email;
            Username = username;
            Password = password;
            Phone = phone;
            Firstname = firstname;
            Lastname = lastname;
            City = city;
            Street = street;
            Number = number;
            Zipcode = zipcode;
            Lat = lat;
            Long = @long;
            Status = status;
            Role = role;
        }
                
        [JsonConstructor]
        public User(
            int id,
            string email,
            string username,
            string password,
            string phone,
            string firstname,
            string lastname,
            string city,
            string street,
            int number,
            string zipcode,
            string lat,
            string @long,
            UserStatus status,
            UserRole role
        )
        {
            Id = id;
            Email = email;
            Username = username;
            Password = password;
            Phone = phone;
            Firstname = firstname;
            Lastname = lastname;
            City = city;
            Street = street;
            Number = number;
            Zipcode = zipcode;
            Lat = lat;
            Long = @long;
            Status = status;
            Role = role;
        }

        private void ValidateDomain(
            string email,
            string username,
            string password,
            string phone,
            string firstname,
            string lastname,
            string city,
            string street,
            int number,
            string zipcode,
            string lat,
            string @long,
            UserStatus status,
            UserRole role)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            DomainValidation.When(!match.Success, "Invalid Email. Not valid Email format.");
            DomainValidation.WhenRequired(email, "Email");
            DomainValidation.NotInRange(email.Length, 5, 100, "Email");

            DomainValidation.WhenRequired(username, "Username");
            DomainValidation.NotInRange(username.Length, 3, 40, "Username");

            DomainValidation.WhenRequired(Password, "Password");
            DomainValidation.NotInRange(password.Length, 8, 512, "Password");

            DomainValidation.WhenRequired(phone, "Phone");
            DomainValidation.NotInRange(phone.Length, 8, 20, "Phone");

            DomainValidation.WhenRequired(firstname, "Firstname");
            DomainValidation.NotInRange(firstname.Length, 3, 100, "Firstname");

            DomainValidation.WhenRequired(lastname, "Lastname");
            DomainValidation.NotInRange(lastname.Length, 3, 100, "Lastname");

            DomainValidation.WhenRequired(city, "City");
            DomainValidation.NotInRange(city.Length, 3, 100, "City");

            DomainValidation.WhenRequired(street, "Street");
            DomainValidation.NotInRange(street.Length, 3, 100, "Street");
                        
            DomainValidation.NotInRange(number, 1, 100000, "Number");

            DomainValidation.WhenRequired(zipcode, "Zipcode");
            DomainValidation.NotInRange(zipcode.Length, 8, 15, "Street");

            Email = email;
            Username = username;
            Password = password;
            Phone = phone;
            Firstname = firstname;
            Lastname = lastname;

            City = city;
            Street = street;
            Number = number;
            Zipcode = zipcode;
            Lat = lat;
            Long = @long;
            Status = status;
            Role = role;
        }
    }
}
