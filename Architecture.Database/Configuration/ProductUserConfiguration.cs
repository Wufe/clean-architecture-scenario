using Architecture.Database.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Architecture.Database.Entities;
using Architecture.Database.Entities.Shared;

namespace Architecture.Database.Configuration
{
    public static class ProductUserConfiguration
    {
        public static void ConfigureProductUser(this ModelBuilder builder)
        {
            builder.Entity<ProductUser>()
                .HasKey(t => new { t.ProductId, t.UserId });

            builder.Entity<ProductUser>()
                .HasOne(c => c.Product)
                .WithMany(p => p.ProductUsers)
                .HasForeignKey(c => c.ProductId);

            builder.Entity<ProductUser>()
                .HasOne(c => c.User)
                .WithMany(u => u.ProductUsers)
                .HasForeignKey(c => c.UserId);
        }
    }
}
