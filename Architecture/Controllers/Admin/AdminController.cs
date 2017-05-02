using Architecture.Services;
using Architecture.ViewModels.Category;
using Architecture.ViewModels.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Architecture.Mvc.Controllers.Admin
{
    [Authorize]
    [Produces("application/json")]
    [Route("admin")]
    public class AdminController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public AdminController(
            ICategoryService categoryService,
            IProductService productService
        )
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("categories")]
        public IActionResult ListCategories()
        {
            var model = new ListCategoriesViewModel()
            {
                Categories =
                    _categoryService
                        .GetAllCategoriesBase()
            };
            return View(model);
        }

        [Route("products")]
        public IActionResult ListProducts()
        {
            var model = new ListProductsViewModel()
            {
                Products =
                    _productService
                        .GetAllProductsBase()
            };
            return View(model);
        }
    }
}