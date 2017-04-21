using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Architecture.Database.Entities;
using Architecture.Database.Common;
using Microsoft.Extensions.Configuration;

namespace Architecture.Database
{
    public class IdentityContext : IdentityDbContext<User, IdentityRole<int>, int>, IDbContext
    {
        protected readonly IConfigurationRoot _configuration;

        public DbSet<User> User { get; set; }

        public IdentityContext(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
                _configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
