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
    public class IdentityContext : DatabaseContext, IDbContext
    {
        public IdentityContext(IConfigurationRoot configuration) : base(configuration)
        {
        }

        public DbSet<User> User { get; set; }
    }
}
