using Architecture.Database.Entities;
using System.Security.Claims;

namespace Architecture.Services
{
    public interface IUserService
    {
        User GetUserByClaim(ClaimsPrincipal userClaim);
        int GetUserIdByClaim(ClaimsPrincipal userClaim);
    }
}
