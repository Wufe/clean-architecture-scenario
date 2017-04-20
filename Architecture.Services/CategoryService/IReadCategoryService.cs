using Architecture.Models.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Services.CategoryService
{
    public interface IReadCategoryService
    {
        CategoryBase GetCategoryBase(int id);
        CategoryFull GetCategoryFull(int id);
        IEnumerable<CategoryBase> GetAllCategoriesBase();
    }
}
