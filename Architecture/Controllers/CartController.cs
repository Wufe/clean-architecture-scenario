using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Architecture.ViewModels.Cart;
using Architecture.Services;

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
            if (cart == null)
                return RedirectToAction("Index", "Home", null);
            var model = new ShowCartViewModel()
            {
                UserId = cart.UserId,
                Products = cart.Products
            };
            return View(model);
        }
    }
}