using Microsoft.EntityFrameworkCore;
using NetCore.Ambev.Abstractions.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NetCore.Ambev.Infra.Context.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Title).HasMaxLength(100).IsRequired();
            builder.Property(m => m.Price).HasMaxLength(100).IsRequired();
            builder.Property(m => m.Description).HasMaxLength(1024).IsRequired();
            builder.Property(m => m.Category).HasMaxLength(100).IsRequired();
            builder.Property(m => m.Image).HasMaxLength(1024).IsRequired();
            builder.Property(m => m.Rate).IsRequired();
            builder.Property(m => m.RateCount).IsRequired();

            builder.HasData(
                new Product(1, "Smartwatch XYZ", 299.99m, "Smart watch with heart rate monitoring, GPS, and AMOLED display.", "Electronics", "https://example.com/smartwatch.jpg", 4.8m, 120),
                new Product(2, "Headphone ABC", 149.90m, "Wireless headphones with active noise cancellation.", "Electronics", "https://example.com/headphone.jpg", 4.5m, 300),
                new Product(3, "Notebook DEF", 4999.99m, "Gaming laptop with i7 processor and RTX 3070 graphics card.", "Computers", "https://example.com/notebook.jpg", 4.7m, 52),
                new Product(4, "Gaming Chair GHI", 899.90m, "Ergonomic gaming chair with lumbar and armrest support.", "Furniture", "https://example.com/cadeira.jpg", 4.9m, 110),
                new Product(5, "Coffee Maker JKL", 279.00m, "Programmable coffee maker with timer and auto-shutoff.", "Appliances", "https://example.com/cafeteira.jpg", 4.2m, 85),
                new Product(6, "Smartphone MNO", 1299.99m, "Smartphone with OLED screen, triple camera, and long-lasting battery.", "Electronics", "https://example.com/smartphone.jpg", 4.3m, 256),
                new Product(7, "Sneakers PQR", 199.90m, "Comfortable and breathable athletic shoes.", "Sports", "https://example.com/tenis.jpg", 4.6m, 180),
                new Product(8, "Book RST", 39.90m, "Best-selling science fiction book.", "Books", "https://example.com/livro.jpg", 4.8m, 42),
                new Product(9, "Smart TV UVW", 2499.99m, "4K Smart TV with HDR and artificial intelligence.", "Electronics", "https://example.com/smartTV.jpg", 4.9m, 147),
                new Product(10, "Video Game XYZ", 2999.90m, "Next-generation gaming console with exclusive games.", "Games", "https://example.com.videogame.jpg", 4.7m, 190)
            );
        }
    }
}
