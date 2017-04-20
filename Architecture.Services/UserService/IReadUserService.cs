using Architecture.Database.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Architecture.Services.UserService
{
    public interface IReadUserService
    {
        User GetUserByClaim(ClaimsPrincipal userClaim);
        int GetUserIdByClaim(ClaimsPrincipal userClaim);
    }
}
