using Architecture.Database.Common;
using Architecture.Database.Configuration;
using Architecture.Database.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Tests.Database
{
    public class DatabaseContextTest : IdentityDbContext<User, IdentityRole<int>, int>, IDbContext
    {
        protected readonly IConfigurationRoot _configuration;

        public DatabaseContextTest(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ConfigureProductCategory();
            builder.ConfigureProductTag();
            builder.ConfigureProductUser();
            builder.ConfigureRating();
        }
    }
}
