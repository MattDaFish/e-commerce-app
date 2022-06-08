using JustSports.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustSports.Infrastructure.Data.Config
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired();

            builder.Property(p => p.Name).IsRequired().HasMaxLength(60);
            builder.Property(p => p.Surname).IsRequired().HasMaxLength(60);
            builder.Property(p => p.CellNumber).IsRequired().HasMaxLength(15);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(250);
            builder.Property(p => p.Password).IsRequired().HasMaxLength(100);
            builder.Property(p => p.IsEmailVerified).IsRequired();

        }
    }
}