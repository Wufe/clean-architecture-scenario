using Architecture.Models.Cart;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Architecture.Services.CartService
{
    public interface IReadCartService
    {
        ICartFull GetCart(int userId);
        ICartFull GetCart(ClaimsPrincipal userClaim);
    }
}
