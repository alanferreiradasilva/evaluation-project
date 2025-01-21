using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCore.Ambev.Abstractions.Entities;

namespace NetCore.Ambev.Infra.Context.EntityConfigurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.UserId).IsRequired();
            builder.Property(m => m.Date).IsRequired();

            builder.HasMany(x => x.CartProducts)
                .WithOne(y => y.Cart)
                .HasForeignKey(z => z.CartId)
                .IsRequired();
        }
    }
}
