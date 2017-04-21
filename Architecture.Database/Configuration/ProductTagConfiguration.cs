using Architecture.Database.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Architecture.Database.Entities;
using Architecture.Database.Entities.Shared;

namespace Architecture.Database.Configuration
{
    public static class ProductTagConfiguration
    {
        public static void ConfigureProductTag(this ModelBuilder builder)
        {
            builder.Entity<ProductTag>()
                .HasKey(t => new { t.TagId, t.ProductId });

            builder.Entity<ProductTag>()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.ProductTags)
                .HasForeignKey(pt => pt.ProductId);

            builder.Entity<ProductTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(p => p.ProductTags)
                .HasForeignKey(pt => pt.TagId);
        }
    }
}
