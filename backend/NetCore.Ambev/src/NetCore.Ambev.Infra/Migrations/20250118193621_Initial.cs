using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NetCore.Ambev.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "numeric", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    Category = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Image = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    Rate = table.Column<decimal>(type: "numeric", nullable: false),
                    RateCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Image", "Price", "Rate", "RateCount", "Title" },
                values: new object[,]
                {
                    { 1, "Electronics", "Smart watch with heart rate monitoring, GPS, and AMOLED display.", "https://example.com/smartwatch.jpg", 299.99m, 4.8m, 120, "Smartwatch XYZ" },
                    { 2, "Electronics", "Wireless headphones with active noise cancellation.", "https://example.com/headphone.jpg", 149.90m, 4.5m, 300, "Headphone ABC" },
                    { 3, "Computers", "Gaming laptop with i7 processor and RTX 3070 graphics card.", "https://example.com/notebook.jpg", 4999.99m, 4.7m, 52, "Notebook DEF" },
                    { 4, "Furniture", "Ergonomic gaming chair with lumbar and armrest support.", "https://example.com/cadeira.jpg", 899.90m, 4.9m, 110, "Gaming Chair GHI" },
                    { 5, "Appliances", "Programmable coffee maker with timer and auto-shutoff.", "https://example.com/cafeteira.jpg", 279.00m, 4.2m, 85, "Coffee Maker JKL" },
                    { 6, "Electronics", "Smartphone with OLED screen, triple camera, and long-lasting battery.", "https://example.com/smartphone.jpg", 1299.99m, 4.3m, 256, "Smartphone MNO" },
                    { 7, "Sports", "Comfortable and breathable athletic shoes.", "https://example.com/tenis.jpg", 199.90m, 4.6m, 180, "Sneakers PQR" },
                    { 8, "Books", "Best-selling science fiction book.", "https://example.com/livro.jpg", 39.90m, 4.8m, 42, "Book RST" },
                    { 9, "Electronics", "4K Smart TV with HDR and artificial intelligence.", "https://example.com/smartTV.jpg", 2499.99m, 4.9m, 147, "Smart TV UVW" },
                    { 10, "Games", "Next-generation gaming console with exclusive games.", "https://example.com.videogame.jpg", 2999.90m, 4.7m, 190, "Video Game XYZ" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
