using Architecture.Database.Common;
using Architecture.Database.Configuration;
using Architecture.Database.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Database
{
    public class DatabaseContext : IdentityDbContext<User, IdentityRole<int>, int>, IDbContext
    {
        protected readonly IConfigurationRoot _configuration;

        public DatabaseContext(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
                _configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ConfigureCulture();
            builder.ConfigureLocalization();
            builder.ConfigureProductCategory();
            builder.ConfigureProductTag();
            builder.ConfigureProductUser();
            builder.ConfigureRating();
        }
    }
}
