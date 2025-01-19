using Microsoft.EntityFrameworkCore;
using NetCore.Ambev.Abstractions.Entities;
using NetCore.Ambev.Infra.Context.EntityConfigurations;

namespace NetCore.Ambev.Infra.Context
{
    public class AmbevDbContext : DbContext
    {
        public AmbevDbContext(DbContextOptions<AmbevDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
