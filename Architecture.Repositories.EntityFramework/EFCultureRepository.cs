using System;
using System.Collections.Generic;
using System.Text;
using Architecture.Database.Entities;
using Architecture.Repositories.EntityFramework.Common;
using Microsoft.EntityFrameworkCore;

namespace Architecture.Repositories.EntityFramework
{
    public class EFCultureRepository : EFRepository<Culture>, ICultureRepository
    {
        public EFCultureRepository(DbContext context) : base(context)
        {
        }
    }
}
