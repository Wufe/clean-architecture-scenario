using Architecture.Services;
using Microsoft.AspNetCore.Mvc;

namespace Architecture.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/products")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(
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
                    .GetProductMinimal(id);
            return Json(product);
        }

        [Route("{id}/full")]
        public IActionResult ReadFull(int id)
        {
            var product =
                _productService
                    .GetProductFull(id);
            return Json(product);
        }
    }
}