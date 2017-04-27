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
    }
}
