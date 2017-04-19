using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Architecture.Database;
using Architecture.Services.Product;
using Architecture.Services.Category;

namespace Architecture.Controllers
{
    public class HomeController : Controller
    {
        private readonly IReadProductService _readProductService;
        private readonly IWriteProductService _writeProductService;
        private readonly IReadCategoryService _readCategoryService;

        public HomeController(
            IReadCategoryService readCategoryService,
            IReadProductService readProductService,
            IWriteProductService writeProductService
        )
        {
            _readCategoryService = readCategoryService;
            _readProductService = readProductService;
            _writeProductService = writeProductService;
        }
        public IActionResult Index()
        {
            //_writeProductService
            //    .AddProduct("Nome prodotto", "Descrizione prodotto", 2.00, 1, new List<int>() { 1 });
            //var minimalProduct = _readProductService
            //    .GetProductMinimal(1);
            //var category = _readCategoryService
            //    .GetCategoryFull(1);
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
