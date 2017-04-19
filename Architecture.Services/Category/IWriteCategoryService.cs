using Architecture.Models.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Services.Category
{
    public interface IWriteCategoryService
    {
        void AddCategory(string title);

        void UpdateCategoryBase(CategoryBase categoryBase);
    }
}
