using JustSports.Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustSports.Infrastructure.Data.Config
{
    public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired();

            builder.Property(e => e.OrderId).IsRequired();
            builder.HasOne(e => e.Order).WithMany(e => e.OrderItems).HasForeignKey(e => e.OrderId);

            builder.Property(p => p.ProductId).IsRequired();

            builder.Property(p => p.PurchasePrice).IsRequired();
            builder.Property(p => p.Quantity).IsRequired();

        }
    }
}