using Architecture.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Models.User
{
    public interface IUserBase : IEntity
    {
        string UserName { get; set; }
    }
}
