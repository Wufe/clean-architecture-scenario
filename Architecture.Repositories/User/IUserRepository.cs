using Architecture.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Repositories.User
{
    public interface IUserRepository : IRepository<Database.Entities.User>
    {
    }
}
