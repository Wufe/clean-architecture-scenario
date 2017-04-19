using Architecture.Repositories.Brand;
using Architecture.Repositories.EntityFramework.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Architecture.Repositories.EntityFramework
{
    public class EFBrandRepository : EFRepository<Database.Entities.Brand>, IBrandRepository
    {
        public EFBrandRepository(DbContext context) : base(context)
        {
        }
    }
}
