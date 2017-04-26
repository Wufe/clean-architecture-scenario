using Microsoft.AspNetCore.Mvc;
using Architecture.ViewModels.Product;
using Microsoft.AspNetCore.Authorization;
using Architecture.Services;

namespace Architecture.Controllers
{
    [Route("products")]
    public class ProductFrontController : Controller
    {
        private readonly IProductService _productService;

        public ProductFrontController(
            IProductService productService
        )
        {
            _productService = productService;
        }

        [Route("{id}")]
        public IActionResult Read(int id)
        {
            var product =
                _productService
                    .GetProductFull(id);
            if (product == null)
                return NotFound();

            var model = new ShowProductViewModel()
            {
                Id = product.Id,
                Brand = product.Brand,
                Categories = product.Categories,
                Description = product.Description,
                Price = product.Price,
                Name = product.Name,
                Ratings = product.Ratings
            };

            return View(model);
        }

        [Authorize]
        [Route("{id}/tocart")]
        public IActionResult AddToCart(int id)
        {
            _productService
                .AddToCart(id, User);
            return RedirectToAction("Read", new { id });
        }
    }
}