using Architecture.Repositories.EntityFramework.Common;
using Architecture.Repositories.User;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Architecture.Repositories.EntityFramework
{
    public class EFUserRepository : EFRepository<Database.Entities.User>, IUserRepository
    {
        public EFUserRepository(DbContext context) : base(context)
        {
        }
    }
}
