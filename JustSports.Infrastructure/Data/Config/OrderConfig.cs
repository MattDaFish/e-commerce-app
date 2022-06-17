using JustSports.Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustSports.Infrastructure.Data.Config
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired();

            builder.Property(p => p.OrderDate).IsRequired();
            builder.Property(p => p.OrderNumber).IsRequired().HasMaxLength(15);
            builder.Property(p => p.AmountExclVat).IsRequired();
            builder.Property(p => p.Vat).IsRequired();
            builder.Property(p => p.AmountExclVat).IsRequired();
            builder.Property(p => p.OrderStatus).IsRequired().HasMaxLength(15);

            builder.Property(p => p.CustomerId).IsRequired();
            builder.Property(p => p.BasketId).IsRequired();

        }
    }
}