using NetCore.Ambev.Abstractions.Entities.Validations;
using System.Text.Json.Serialization;

namespace NetCore.Ambev.Abstractions.Entities
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }

        public decimal Rate { get; set; }
        public int RateCount { get; set; }

        public Product(string title, decimal price, string description, string category, 
            string image, decimal rate, int rateCount) 
        {
            ValidateDomain(title, price, description, category, image, rate, rateCount);
        }

        public Product() { }

        [JsonConstructor]
        public Product(int id, string title, decimal price, string description, string category,
            string image, decimal rate, int rateCount)
        {
            DomainValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(title, price, description, category, image, rate, rateCount);
        }

        private void ValidateDomain(string title, decimal price, string description, string category,
            string image, decimal rate, int rateCount)
        {
            DomainValidation.When(string.IsNullOrEmpty(title),
                "Invalid Title. Title is required");

            DomainValidation.When(string.IsNullOrEmpty(description),
                "Invalid Description. Description is required");

            DomainValidation.When(string.IsNullOrEmpty(image),
                "Invalid Image. Image is required");

            DomainValidation.When(string.IsNullOrEmpty(category),
                "Invalid Category. Category is required");

            DomainValidation.When(title.Length < 3,
                "Invalid Title, too short, minimum 3 characters");

            DomainValidation.When(price == 0,
                "Invalid Price. Price must be great than ZERO");

            DomainValidation.When(description.Length < 3,
                "Invalid Description, too short, minimum 3 characters");
            
            DomainValidation.When(category.Length < 3,
                "Invalid Category, too short, minimum 3 characters");

            DomainValidation.When(title?.Length > 100,
                "Invalid Title, too long, maximum 100 characters");

            DomainValidation.When(category?.Length > 100,
                "Invalid Category, too long, maximum 100 characters");

            DomainValidation.When(description?.Length > 1024,
                "Invalid Description, too long, maximum 1024 characters");

            DomainValidation.When(image?.Length > 1024,
                "Invalid Image, too long, maximum 1024 characters");

            DomainValidation.When(rate < 0 || rate > 5,
               "Invalid Rate, Rate must be in ragen between 0 and 5");

            DomainValidation.When(rateCount < 0,
                "Invalid Rate Count. Rate Count min value must be ZERO");

            Title = title;
            Description = description;
            Price = price;
            Category = category;
            Image = image;
            Rate = rate;
            RateCount = rateCount;
        }
    }
}
