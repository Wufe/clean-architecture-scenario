using Architecture.Database.Entities;
using Architecture.Repositories.EntityFramework.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Architecture.Repositories.EntityFramework
{
    public class EFLocalizationRepository : EFRepository<Localization>, ILocalizationRepository
    {
        public EFLocalizationRepository(DbContext context) : base(context)
        {
        }

        public void Remove(string culture, string key)
        {
            var localization = new Localization()
            {
                Culture = culture,
                Key = key
            };
            Attach(ref localization,
                l =>
                    l.Culture == culture &&
                    l.Key == key
            );
            Remove(localization);
        }
    }
}
