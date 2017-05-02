using Architecture.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Database.Configuration
{
    public static class LocalizationConfiguration
    {
        public static void ConfigureLocalization(this ModelBuilder builder)
        {
            builder.Entity<Localization>()
                .HasKey(t => new {t.Culture, t.Key});
        }
    }
}
