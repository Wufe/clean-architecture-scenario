using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Architecture.ViewModels.Product;
using Architecture.Services.Product;
using Architecture.Models.Product;

namespace Architecture.Controllers.Admin
{
    [Produces("application/json")]
    [Route("admin/products")]
    public class ProductAdminController : Controller
    {
        private readonly IReadProductService _readProductService;

        public ProductAdminController(
            IReadProductService readProductService
        )
        {
            _readProductService = readProductService;
        }

        [HttpPost]
        [Route("search")]
        public IActionResult Search(ListProductsViewModel model)
        {
            if(!ModelState.IsValid || String.IsNullOrEmpty(model.SearchText))
            {
                model.Products =
                    _readProductService
                        .GetAllProductsMinimal();
                return View("ListProducts", model);
            }

            model.Products =
                    _readProductService
                        .SearchProductsMinimal(model.SearchText);

            return View("ListProducts", model);
        }

        [HttpGet]
        [Route("{id}/update")]
        public IActionResult Update(int id)
        {
            var product =
                _readProductService
                    .GetProductBase(id);
            if (product == null)
                return NotFound();

            var model = new UpdateProductViewModel()
            {
                Product = product
            };
        }

        private void _PopulateBrands(GenericEditProductViewModel model)
        {

        }

        private void _PopulateCategories(GenericEditProductViewModel model)
        {

        }

        private void _PopulateRatings(GenericEditProductViewModel model)
        {

        }
    }
}