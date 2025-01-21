using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCore.Ambev.Abstractions.Entities;

namespace NetCore.Ambev.Infra.Context.EntityConfigurations
{
    public class CartProductConfiguration : IEntityTypeConfiguration<CartProduct>
    {
        public void Configure(EntityTypeBuilder<CartProduct> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Quantity).IsRequired();

            //builder.HasOne(x => x.Product)
            //   .WithMany()
            //   .HasForeignKey(x => x.ProductId)
            //   .IsRequired();

            
            //builder.HasOne(cp => cp.Cart)
            //       .WithMany(c => c.CartProducts)
            //       .HasForeignKey(cp => cp.CartId);

            //builder.HasOne(cp => cp.Product)
            //       .WithMany()
            //       .HasForeignKey(cp => cp.ProductId);
        }
    }
}
