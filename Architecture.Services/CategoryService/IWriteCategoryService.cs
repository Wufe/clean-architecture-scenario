using Architecture.Models.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Services.CategoryService
{
    public interface IWriteCategoryService
    {
        void AddCategory(string title);

        void UpdateCategoryBase(CategoryBase categoryBase);
    }
}
