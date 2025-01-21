using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCore.Ambev.Abstractions.Entities;

namespace NetCore.Ambev.Infra.Context.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Email).HasMaxLength(100).IsRequired();
            builder.Property(m => m.Username).HasMaxLength(40).IsRequired();
            builder.Property(m => m.Password).HasMaxLength(512).IsRequired();
            builder.Property(m => m.Firstname).HasMaxLength(100).IsRequired();
            builder.Property(m => m.Lastname).HasMaxLength(100).IsRequired();

            builder.Property(m => m.City).HasMaxLength(100).IsRequired();
            builder.Property(m => m.Street).HasMaxLength(100).IsRequired();
            builder.Property(m => m.Number).IsRequired();
            builder.Property(m => m.Zipcode).HasMaxLength(15).IsRequired();

            builder.Property(m => m.Lat).HasMaxLength(20);
            builder.Property(m => m.Long).HasMaxLength(20);

            builder.Property(m => m.Status).IsRequired();
            builder.Property(m => m.Role).IsRequired();

            builder.HasData(
                new User(1, "admin@mail.com", "admin", "fcf41657f02f88137a1bcf068a32c0a3", "0000-0000", "Admin", "Brazil", "Rio", "Liberty", 100, "00000-000", null, null, UserStatus.Active, UserRole.Admin),
                new User(2, "manager@mail.com", "manager", "fcf41657f02f88137a1bcf068a32c0a3", "0000-0000", "John", "Doe", "Rio", "Liberty", 100, "00000-000", null, null, UserStatus.Active, UserRole.Manager),
                new User(3, "guest@mail.com", "guest", "fcf41657f02f88137a1bcf068a32c0a3", "0000-0000", "Guest", "da Silva", "Rio", "Liberty", 100, "00000-000", null, null, UserStatus.Active, UserRole.Customer)
            );
        }
    }
}
