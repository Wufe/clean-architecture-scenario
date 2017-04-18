using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Architecture.ViewModels.Category;
using Architecture.Services.Category;

namespace Architecture.Controllers.Admin
{
    [Produces("application/json")]
    [Route("admin")]
    public class AdminController : Controller
    {
        private readonly IReadCategoryService _readCategoryService;

        public AdminController(
            IReadCategoryService readCategoryService
        )
        {
            _readCategoryService = readCategoryService;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("categories")]
        public IActionResult ListCategories()
        {
            var model = new ListCategoryViewModel()
            {
                Categories =
                    _readCategoryService
                        .GetAllCategoriesBase()
            };
            return View(model);
        }
    }
}