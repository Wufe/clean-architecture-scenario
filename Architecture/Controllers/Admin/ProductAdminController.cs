using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Architecture.ViewModels.Product;
using Architecture.Services.Product;
using Architecture.Models.Product;
using Architecture.Services.Brand;
using Microsoft.AspNetCore.Mvc.Rendering;
using Architecture.Services.Category;
using Architecture.Services.Rating;
using Architecture.Models.Brand;
using Architecture.Models.Category;

namespace Architecture.Controllers.Admin
{
    [Produces("application/json")]
    [Route("admin/products")]
    public class ProductAdminController : Controller
    {
        private readonly IReadBrandService _readBrandService;
        private readonly IReadCategoryService _readCategoryService;
        private readonly IReadProductService _readProductService;
        private readonly IReadRatingService _readRatingService;
        private readonly IWriteProductService _writeProductService;

        public ProductAdminController(
            IReadBrandService readBrandService,
            IReadCategoryService readCategoryService,
            IReadProductService readProductService,
            IReadRatingService readRatingService,
            IWriteProductService writeProductService
            
        )
        {
            _readBrandService = readBrandService;
            _readCategoryService = readCategoryService;
            _readProductService = readProductService;
            _readRatingService = readRatingService;
            _writeProductService = writeProductService;
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
                    .GetProductFull(id);
            if (product == null)
                return NotFound();

            var model = new UpdateProductViewModel()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };

            _PopulateBrands(model, product.Brand.Id.ToString());
            _PopulateCategories(
                model,
                product
                    .Categories
                    .Select(x => x.Id.ToString())
            );
            _PopulateRatings(model, product.Id);

            return View(model);
        }

        [HttpPost]
        [Route("{id}/update")]
        public async Task<IActionResult> Update(int id, UpdateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product =
                    _readProductService
                        .GetProductBase(id);

                var selectedCategoriesIds =
                    model
                        .SelectedCategories
                        .Select(x => int.Parse(x));
                var selectedBrandId =
                    int.Parse(
                        model
                            .SelectedBrand
                    );
                if (await TryUpdateModelAsync(product))
                {
                    _writeProductService
                        .UpdateProductBase(product, selectedBrandId, selectedCategoriesIds);
                    return RedirectToAction("ListProducts", "Admin", null);
                }
                
            }
            _PopulateBrands(model);
            _PopulateCategories(model);
            _PopulateRatings(model);
            return View(model);
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            var model = new CreateProductViewModel();
            _PopulateBrands(model);
            _PopulateCategories(model);
            return View(model);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(CreateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var selectedCategoriesIds =
                    model
                        .SelectedCategories
                        .Select(x => int.Parse(x));

                var selectedBrandId =
                    int.Parse(
                        model
                            .SelectedBrand
                    );

                _writeProductService
                    .AddProduct(model.Name, model.Description, model.Price, selectedBrandId, selectedCategoriesIds);
                return RedirectToAction("ListProducts", "Admin", null);
            }
            _PopulateBrands(model, model.SelectedBrand);
            _PopulateCategories(model, model.SelectedCategories);
            return View();
        }

        private void _PopulateBrands(GenericEditProductViewModel model, string selectedBrand = null)
        {
            model.BrandsList =
                _readBrandService
                    .GetAllBrandsBase()
                    .Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    });

            model.SelectedBrand = selectedBrand;
        }

        private void _PopulateCategories(GenericEditProductViewModel model, IEnumerable<string> selectedCategories = null)
        {
            model.CategoriesList =
                _readCategoryService
                    .GetAllCategoriesBase()
                    .Select(x => new SelectListItem
                    {
                        Text = x.Title,
                        Value = x.Id.ToString()
                    });

            model.SelectedCategories = selectedCategories;
        }

        private void _PopulateRatings(GenericEditProductViewModel model, int productId = -1)
        {
            if(productId != -1)
                model.RatingsList =
                    _readRatingService
                        .GetRatingsBaseByProduct(productId);
        }
    }
}