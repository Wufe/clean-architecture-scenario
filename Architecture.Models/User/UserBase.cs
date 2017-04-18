using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Models.User
{
    public class UserBase : IUserBase
    {
        public int Id { get; set; }

        public string UserName { get; set; }
    }
}
