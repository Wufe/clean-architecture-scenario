using Architecture.Database.Common;
using Architecture.Database.Configuration;
using Architecture.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Architecture.Database.Entities.Shared;

namespace Architecture.Database
{
    public class DataContext : IdentityContext, IDbContext
    {
        public DataContext(IConfigurationRoot configuration) : base(configuration)
        {
        }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductUser> ProductUsers { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<Tag> Tags { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
                _configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ConfigureProductCategory();
            builder.ConfigureProductTag();
            builder.ConfigureProductUser();
            builder.ConfigureRating();
            base.OnModelCreating(builder);
        }
    }
}
