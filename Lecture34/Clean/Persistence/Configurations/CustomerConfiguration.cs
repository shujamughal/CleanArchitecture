using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // Define properties and constraints
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            // Seed initial data
            builder.HasData(
                new Customer
                {
                    Id = 1,
                    Name = "John Doe",
                    Email = "john.doe@example.com",
                    CreatedDate = DateTime.Now
                }
            );
        }
    }

}
