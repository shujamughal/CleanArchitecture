using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                new ApplicationUser
                {
                    Id = "101", // Static ID for Admin user
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@example.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Admin@123"),
                    FirstName = "Admin",
                    LastName = "User"
                },
                new ApplicationUser
                {
                    Id = "102", // Static ID for Employee user
                    UserName = "employee",
                    NormalizedUserName = "EMPLOYEE",
                    Email = "employee@example.com",
                    NormalizedEmail = "EMPLOYEE@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Employee@123"),
                    FirstName = "Prakash",
                    LastName = "Tripathi"
                }
            );
        }
    }
}
