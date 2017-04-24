using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Architecture.ViewModels.Category;
using Microsoft.AspNetCore.Authorization;
using Architecture.Services;
using Architecture.Models;

namespace Architecture.Controllers.Admin
{
    [Authorize]
    [Produces("application/json")]
    [Route("admin/categories")]
    public class CategoryAdminController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryAdminController(
            ICategoryService categoryService
        )
        {
            _categoryService = categoryService;
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
            _categoryService
                .AddCategory(model.Title);
            return RedirectToAction("ListCategories", "Admin", null);
        }
        
        [HttpGet]
        [Route("{id}/update")]
        public IActionResult Update(int id)
        {
            var category =
                _categoryService
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
            var category = new CategoryBase()
            {
                Id = id,
                Title = model.Title
            };
            if (!await TryUpdateModelAsync(category))
                return View(model);
            _categoryService
                .UpdateCategoryBase(category);
            return RedirectToAction("ListCategories", "Admin", null);
        }

        [HttpGet]
        [Route("{id}/delete")]
        public IActionResult Delete(int id)
        {
            _categoryService
                .Delete(id);
            return RedirectToAction("ListCategories", "Admin", null);
        }
    }
}