using System;
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
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Username = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Password = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Firstname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Lastname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Street = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    Zipcode = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Lat = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Long = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CartProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    CartId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartProduct_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "Email", "Firstname", "Lastname", "Lat", "Long", "Number", "Password", "Phone", "Role", "Status", "Street", "Username", "Zipcode" },
                values: new object[,]
                {
                    { 1, "Rio", "admin@mail.com", "Admin", "Brazil", null, null, 100, "fcf41657f02f88137a1bcf068a32c0a3", "0000-0000", 2, 0, "Liberty", "admin", "00000-000" },
                    { 2, "Rio", "manager@mail.com", "John", "Doe", null, null, 100, "fcf41657f02f88137a1bcf068a32c0a3", "0000-0000", 1, 0, "Liberty", "manager", "00000-000" },
                    { 3, "Rio", "guest@mail.com", "Guest", "da Silva", null, null, 100, "fcf41657f02f88137a1bcf068a32c0a3", "0000-0000", 0, 0, "Liberty", "guest", "00000-000" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_CartId",
                table: "CartProduct",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_ProductId",
                table: "CartProduct",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartProduct");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
