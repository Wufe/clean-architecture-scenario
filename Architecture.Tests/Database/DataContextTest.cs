using Architecture.Database;
using Architecture.Database.Common;
using Architecture.Database.Entities;
using Architecture.Database.Entities.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Tests.Database
{
    public class DataContextTest : IdentityContextTest, IDbContext
    {
        public DataContextTest(IConfigurationRoot configuration) : base(configuration)
        {
        }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductUser> ProductUsers { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }
}
