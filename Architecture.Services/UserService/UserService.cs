using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Architecture.Database.Entities;
using Architecture.Repositories.User;
using System.Linq;

namespace Architecture.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(
            IUserRepository userRepository
        )
        {
            _userRepository = userRepository;
        }

        public User GetUserByClaim(ClaimsPrincipal userClaim)
        {
            var name = userClaim.Identity.Name;
            if (name == null)
                throw new ArgumentNullException("ClaimsPrincipal.Identity.Name");
            var user =
                _userRepository
                    .GetAll()
                    .Where(x => x.UserName.Equals(name))
                    .FirstOrDefault();
            return user;
        }

        public int GetUserIdByClaim(ClaimsPrincipal userClaim)
        {
            var user = GetUserByClaim(userClaim);
            return user != null ? user.Id : default(int);
        }
    }
}
