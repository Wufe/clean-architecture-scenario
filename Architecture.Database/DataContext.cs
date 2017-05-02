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

        public DbSet<Culture> Cultures { get; set; }

        public DbSet<Localization> Localizations { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductUser> ProductUsers { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<Tag> Tags { get; set; }

    }
}
