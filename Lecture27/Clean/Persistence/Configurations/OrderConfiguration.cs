using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Define properties and constraints
            builder.Property(o => o.OrderNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(o => o.TotalAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(o => o.CustomerId)
                .IsRequired();

            // Define the relationship between Order and Customer
            builder.HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);

            // Seed initial data
            builder.HasData(
                new Order
                {
                    Id = 1,
                    OrderNumber = "ORD001",
                    TotalAmount = 100.50m,
                    CustomerId = 1,
                    CreatedDate = DateTime.Now
                }
            );
        }
    }

}
