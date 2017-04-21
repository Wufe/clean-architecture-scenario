using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Architecture.Services.CartService;
using Microsoft.AspNetCore.Authorization;
using Architecture.ViewModels.Cart;

namespace Architecture.Controllers
{
    [Route("cart")]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(
            ICartService cartService
        )
        {
            _cartService = cartService;
        }

        [Authorize]
        [Route("")]
        public IActionResult Index()
        {
            var cart =
                _cartService
                    .GetCart(User);
            var model = new ShowCartViewModel()
            {
                UserId = cart.UserId,
                Products = cart.Products
            };
            return View(model);
        }
    }
}