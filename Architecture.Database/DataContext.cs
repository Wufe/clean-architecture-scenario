using Architecture.Database.Common;
using Architecture.Database.Configuration;
using Architecture.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Database
{
    public class DataContext : IdentityContext, IDbContext
    {
        public DbSet<Brand> Brands { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<ProductTag> ProductTags { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DataContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-Architecture-77e12622-3a30-4603-a018-866ba0ccb822;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ConfigureCart();
            builder.ConfigureProductCategory();
            builder.ConfigureProductTag();
            builder.ConfigureRating();
        }
    }
}
