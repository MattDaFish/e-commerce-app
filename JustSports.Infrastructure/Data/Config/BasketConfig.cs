using JustSports.Core.Entities.BasketAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustSports.Infrastructure.Data.Config
{
    public class BasketConfig : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.ToTable("Basket");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired();

            builder.Property(p => p.CreatedDate).IsRequired();
            builder.Property(p => p.CustomerId).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();
        }
    }
}