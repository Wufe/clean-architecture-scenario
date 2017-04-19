using Architecture.Database.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Architecture.Database.Entities;

namespace Architecture.Database.Configuration
{
    public static class CartConfiguration
    {
        public static void ConfigureCart(this ModelBuilder builder)
        {
            builder.Entity<Cart>()
                .HasKey(t => new { t.ProductId, t.UserId });

            builder.Entity<Cart>()
                .HasOne(c => c.Product)
                .WithMany(p => p.Carts)
                .HasForeignKey(c => c.ProductId);

            builder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithMany(u => u.Carts)
                .HasForeignKey(c => c.UserId);
        }
    }
}
