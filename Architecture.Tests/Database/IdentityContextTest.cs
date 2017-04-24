using Architecture.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Tests.Database
{
    public class IdentityContextTest : DatabaseContextTest
    {
        public IdentityContextTest(IConfigurationRoot configuration) : base(configuration)
        {
        }

        public DbSet<User> User { get; set; }
    }
}
