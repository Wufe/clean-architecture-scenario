using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Architecture.Database.Entities;

namespace Architecture.Database.Configuration
{
    public static class CultureConfiguration
    {
        public static void ConfigureCulture(this ModelBuilder builder)
        {
            builder.Entity<Culture>()
                .HasKey(t => t.Name);
        }
    }
}
