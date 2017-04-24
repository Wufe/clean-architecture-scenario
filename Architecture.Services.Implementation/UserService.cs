using AutoMapper.QueryableExtensions;
using System;
using System.Security.Claims;
using Architecture.Database.Entities;
using System.Linq;
using Architecture.Models;
using Architecture.Repositories;

namespace Architecture.Services
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
            var name = userClaim.Identity.Name;
            if(name == null)
                throw new ArgumentNullException("ClaimsPrincipal.Identity.Name");
            var user =
                _userRepository
                    .GetAll()
                    .Where(x => x.UserName.Equals(name))
                    .ProjectTo<UserBase>()
                    .FirstOrDefault();
            return user != null ? user.Id : default(int);
        }
    }
}
