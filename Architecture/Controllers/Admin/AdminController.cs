using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Architecture.ViewModels.Category;
using Architecture.ViewModels.Product;
using Architecture.Services.CategoryService;
using Architecture.Services.ProductService;
using Microsoft.AspNetCore.Authorization;

namespace Architecture.Controllers.Admin
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
                        .GetAllProductsMinimal()
            };
            return View(model);
        }
    }
}