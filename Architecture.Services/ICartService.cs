using Architecture.Models;
using System.Security.Claims;

namespace Architecture.Services
{
    public interface ICartService
    {
        CartFull GetCart(int userId);
        CartFull GetCart(ClaimsPrincipal userClaim);
    }
}
