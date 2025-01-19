﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetCore.Ambev.Infra.Context;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NetCore.Ambev.Infra.Migrations
{
    [DbContext(typeof(AmbevDbContext))]
    partial class AmbevDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NetCore.Ambev.Abstractions.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)");

                    b.Property<decimal>("Price")
                        .HasMaxLength(100)
                        .HasColumnType("numeric");

                    b.Property<decimal>("Rate")
                        .HasColumnType("numeric");

                    b.Property<int>("RateCount")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Electronics",
                            Description = "Smart watch with heart rate monitoring, GPS, and AMOLED display.",
                            Image = "https://example.com/smartwatch.jpg",
                            Price = 299.99m,
                            Rate = 4.8m,
                            RateCount = 120,
                            Title = "Smartwatch XYZ"
                        },
                        new
                        {
                            Id = 2,
                            Category = "Electronics",
                            Description = "Wireless headphones with active noise cancellation.",
                            Image = "https://example.com/headphone.jpg",
                            Price = 149.90m,
                            Rate = 4.5m,
                            RateCount = 300,
                            Title = "Headphone ABC"
                        },
                        new
                        {
                            Id = 3,
                            Category = "Computers",
                            Description = "Gaming laptop with i7 processor and RTX 3070 graphics card.",
                            Image = "https://example.com/notebook.jpg",
                            Price = 4999.99m,
                            Rate = 4.7m,
                            RateCount = 52,
                            Title = "Notebook DEF"
                        },
                        new
                        {
                            Id = 4,
                            Category = "Furniture",
                            Description = "Ergonomic gaming chair with lumbar and armrest support.",
                            Image = "https://example.com/cadeira.jpg",
                            Price = 899.90m,
                            Rate = 4.9m,
                            RateCount = 110,
                            Title = "Gaming Chair GHI"
                        },
                        new
                        {
                            Id = 5,
                            Category = "Appliances",
                            Description = "Programmable coffee maker with timer and auto-shutoff.",
                            Image = "https://example.com/cafeteira.jpg",
                            Price = 279.00m,
                            Rate = 4.2m,
                            RateCount = 85,
                            Title = "Coffee Maker JKL"
                        },
                        new
                        {
                            Id = 6,
                            Category = "Electronics",
                            Description = "Smartphone with OLED screen, triple camera, and long-lasting battery.",
                            Image = "https://example.com/smartphone.jpg",
                            Price = 1299.99m,
                            Rate = 4.3m,
                            RateCount = 256,
                            Title = "Smartphone MNO"
                        },
                        new
                        {
                            Id = 7,
                            Category = "Sports",
                            Description = "Comfortable and breathable athletic shoes.",
                            Image = "https://example.com/tenis.jpg",
                            Price = 199.90m,
                            Rate = 4.6m,
                            RateCount = 180,
                            Title = "Sneakers PQR"
                        },
                        new
                        {
                            Id = 8,
                            Category = "Books",
                            Description = "Best-selling science fiction book.",
                            Image = "https://example.com/livro.jpg",
                            Price = 39.90m,
                            Rate = 4.8m,
                            RateCount = 42,
                            Title = "Book RST"
                        },
                        new
                        {
                            Id = 9,
                            Category = "Electronics",
                            Description = "4K Smart TV with HDR and artificial intelligence.",
                            Image = "https://example.com/smartTV.jpg",
                            Price = 2499.99m,
                            Rate = 4.9m,
                            RateCount = 147,
                            Title = "Smart TV UVW"
                        },
                        new
                        {
                            Id = 10,
                            Category = "Games",
                            Description = "Next-generation gaming console with exclusive games.",
                            Image = "https://example.com.videogame.jpg",
                            Price = 2999.90m,
                            Rate = 4.7m,
                            RateCount = 190,
                            Title = "Video Game XYZ"
                        });
                });

            modelBuilder.Entity("NetCore.Ambev.Abstractions.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Lat")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Long")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("Zipcode")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Rio",
                            Email = "admin@mail.com",
                            Firstname = "Admin",
                            Lastname = "Brazil",
                            Number = 100,
                            Password = "fcf41657f02f88137a1bcf068a32c0a3",
                            Phone = "0000-0000",
                            Role = 2,
                            Status = 0,
                            Street = "Liberty",
                            Username = "admin",
                            Zipcode = "00000-000"
                        },
                        new
                        {
                            Id = 2,
                            City = "Rio",
                            Email = "manager@mail.com",
                            Firstname = "John",
                            Lastname = "Doe",
                            Number = 100,
                            Password = "fcf41657f02f88137a1bcf068a32c0a3",
                            Phone = "0000-0000",
                            Role = 1,
                            Status = 0,
                            Street = "Liberty",
                            Username = "manager",
                            Zipcode = "00000-000"
                        },
                        new
                        {
                            Id = 3,
                            City = "Rio",
                            Email = "guest@mail.com",
                            Firstname = "Guest",
                            Lastname = "da Silva",
                            Number = 100,
                            Password = "fcf41657f02f88137a1bcf068a32c0a3",
                            Phone = "0000-0000",
                            Role = 0,
                            Status = 0,
                            Street = "Liberty",
                            Username = "guest",
                            Zipcode = "00000-000"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
