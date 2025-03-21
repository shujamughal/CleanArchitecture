﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "1", // Static Role ID for Admin
                    UserId = "101" // Static User ID for Admin
                },
                new IdentityUserRole<string>
                {
                    RoleId = "2", // Static Role ID for Employee
                    UserId = "102" // Static User ID for Employee
                }
            );
        }
    }
}
