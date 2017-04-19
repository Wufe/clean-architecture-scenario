using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Architecture.ViewModels.Category;
using Architecture.Services.Category;
using Architecture.Services.Product;
using Architecture.ViewModels.Product;

namespace Architecture.Controllers.Admin
{
    [Produces("application/json")]
    [Route("admin")]
    public class AdminController : Controller
    {
        private readonly IReadCategoryService _readCategoryService;
        private readonly IReadProductService _readProductService;

        public AdminController(
            IReadCategoryService readCategoryService,
            IReadProductService readProductService
        )
        {
            _readCategoryService = readCategoryService;
            _readProductService = readProductService;
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
                    _readCategoryService
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
                    _readProductService
                        .GetAllProductsMinimal()
            };
            return View(model);
        }
    }
}