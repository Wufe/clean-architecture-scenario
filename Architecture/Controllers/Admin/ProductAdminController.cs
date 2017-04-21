using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Architecture.ViewModels.Product;
using Architecture.Models.Product;
using Microsoft.AspNetCore.Mvc.Rendering;
using Architecture.Models.Brand;
using Architecture.Models.Category;
using Architecture.Services.CategoryService;
using Architecture.Services.BrandService;
using Architecture.Services.ProductService;
using Architecture.Services.RatingService;
using Microsoft.AspNetCore.Authorization;

namespace Architecture.Controllers.Admin
{
    [Authorize]
    [Produces("application/json")]
    [Route("admin/products")]
    public class ProductAdminController : Controller
    {
        private readonly IBrandService _brandService;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IRatingService _ratingService;

        public ProductAdminController(
            IBrandService brandService,
            ICategoryService categoryService,
            IProductService productService,
            IRatingService ratingService
        )
        {
            _brandService = brandService;
            _categoryService = categoryService;
            _productService = productService;
            _ratingService = ratingService;
        }

        [HttpPost]
        [Route("search")]
        public IActionResult Search(ListProductsViewModel model)
        {
            if(!ModelState.IsValid || String.IsNullOrEmpty(model.SearchText))
            {
                model.Products =
                    _productService
                        .GetAllProductsMinimal();
                return View("ListProducts", model);
            }

            model.Products =
                    _productService
                        .SearchProductsMinimal(model.SearchText);

            return View("ListProducts", model);
        }

        [HttpGet]
        [Route("{id}/update")]
        public IActionResult Update(int id)
        {
            var product =
                _productService
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
                    _productService
                        .GetProductBase(id);

                var selectedCategoriesIds =
                    model
                        .SelectedCategories?
                        .Select(x => int.Parse(x)) ?? new int[0];
                var selectedBrandId =
                    int.Parse(
                        model
                            .SelectedBrand
                    );
                if (await TryUpdateModelAsync(product))
                {
                    _productService
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
                        .SelectedCategories?
                        .Select(x => int.Parse(x)) ?? new int[0];

                var selectedBrandId =
                    int.Parse(
                        model
                            .SelectedBrand
                    );

                _productService
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
                _brandService
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
                _categoryService
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
                    _ratingService
                        .GetRatingsBaseByProduct(productId);
        }
    }
}