using Architecture.Services;
using Architecture.ViewModels.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Architecture.Mvc.Controllers
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