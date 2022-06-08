using JustSports.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection;

namespace Infrastructure.Data
{
    public class JustSportsDBContext : DbContext
    {
        public JustSportsDBContext(DbContextOptions<JustSportsDBContext> options) : base(options)
        {
        }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        
        public DbSet<Customer> Customers { get; set; }

        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderItem> OrderItems { get; set; }
        //public DbSet<BasketItem> BasketItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //Workaround for sqlite as it doesn't support decimal, datetimeoffset.
            //if(Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            //{
            //    foreach(var item in modelBuilder.Model.GetEntityTypes())
            //    {
            //        var props = item.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));
            //        var dateTimeProperties = item.ClrType.GetProperties().Where(p => p.PropertyType == typeof(DateTimeOffset));
            //        foreach(var prop in props)
            //        {
            //            modelBuilder.Entity(item.Name).Property(prop.Name).HasConversion<double>();
            //        }
            //        foreach (var prop in dateTimeProperties)
            //        {
            //            modelBuilder.Entity(item.Name).Property(prop.Name).HasConversion(new DateTimeOffsetToBinaryConverter());
            //        }
            //    }
            //}
        }
    }
}