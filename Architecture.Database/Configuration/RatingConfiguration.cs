using Architecture.Database.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Architecture.Database.Entities;
using Architecture.Database.Entities.Shared;

namespace Architecture.Database.Configuration
{
    public static class RatingConfiguration
    {
        public static void ConfigureRating(this ModelBuilder builder)
        {
            builder.Entity<Rating>()
                .HasKey(t => new { t.ProductId, t.UserId });

            builder.Entity<Rating>()
                .HasOne(r => r.Product)
                .WithMany(p => p.Ratings)
                .HasForeignKey(r => r.ProductId);

            builder.Entity<Rating>()
                .HasOne(r => r.User)
                .WithMany(u => u.Ratings)
                .HasForeignKey(r => r.UserId);
        }
    }
}
