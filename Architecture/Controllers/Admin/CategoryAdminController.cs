using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Architecture.ViewModels.Category;
using Architecture.Services.CategoryService;

namespace Architecture.Controllers.Admin
{
    [Produces("application/json")]
    [Route("admin/categories")]
    public class CategoryAdminController : Controller
    {
        private readonly IWriteCategoryService _writeCategoryService;
        private readonly IReadCategoryService _readCategoryService;

        public CategoryAdminController(
            IReadCategoryService readCategoryService,
            IWriteCategoryService writeCategoryService
        )
        {
            _readCategoryService = readCategoryService;
            _writeCategoryService = writeCategoryService;
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            var model = new CreateCategoryViewModel()
            {
                Title = ""
            };
            return View(model);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(CreateCategoryViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            _writeCategoryService
                .AddCategory(model.Title);
            return RedirectToAction("ListCategories", "Admin", null);
        }
        
        [HttpGet]
        [Route("{id}/update")]
        public IActionResult Update(int id)
        {
            var category =
                _readCategoryService
                    .GetCategoryBase(id);

            if (category == null)
                return NotFound();

            var model = new UpdateCategoryViewModel()
            {
                Title = category.Title
            };

            return View(model);
        }

        [HttpPost]
        [Route("{id}/update")]
        public async Task<IActionResult> Update(int id, UpdateCategoryViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var category =
                _readCategoryService
                    .GetCategoryBase(id);
            if (!await TryUpdateModelAsync(category))
                return View(model);
            _writeCategoryService
                .UpdateCategoryBase(category);
            return RedirectToAction("ListCategories", "Admin", null);
        }
    }
}