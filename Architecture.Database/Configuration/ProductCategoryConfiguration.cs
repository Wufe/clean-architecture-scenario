using Architecture.Database.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Architecture.Database.Entities;
using Architecture.Database.Entities.Shared;

namespace Architecture.Database.Configuration
{
    public static class ProductCategoryConfiguration
    {
        public static void ConfigureProductCategory(this ModelBuilder builder)
        {
            builder.Entity<ProductCategory>()
                .HasKey(t => new { t.CategoryId, t.ProductId });

            builder.Entity<ProductCategory>()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(pt => pt.ProductId);

            builder.Entity<ProductCategory>()
                .HasOne(pt => pt.Category)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(pt => pt.CategoryId);
        }
    }
}
