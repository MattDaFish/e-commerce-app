using JustSports.Core.Entities.BasketAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustSports.Infrastructure.Data.Config
{
    public class BasketItemConfig : IEntityTypeConfiguration<BasketItem>
    {
        public void Configure(EntityTypeBuilder<BasketItem> builder)
        {
            builder.ToTable("BasketItem");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired();

            builder.Property(e => e.BasketId).IsRequired();
            builder.HasOne(e => e.Basket).WithMany(e => e.BasketItems).HasForeignKey(e => e.BasketId);

            builder.Property(p => p.ProductId).IsRequired();

            builder.Property(p => p.PurchasePrice).IsRequired();
            builder.Property(p => p.Quantity).IsRequired();

        }
    }
}