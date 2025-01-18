namespace NetCore.Ambev.Abstractions.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }        
        public string Phone { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Zipcode { get; set; }

        public string Lat { get; set; }
        public string Long { get; set; }

        public UserStatus Status { get; set; }
        public UserRole Role { get; set; }
    }
}
