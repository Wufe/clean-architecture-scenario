using Architecture.Repositories.EntityFramework.Common;
using Architecture.Repositories.Rating;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Architecture.Repositories.EntityFramework
{
    public class EFRatingRepository : EFRepository<Database.Entities.Rating>, IRatingRepository
    {
        public EFRatingRepository(DbContext context) : base(context)
        {
        }
    }
}
