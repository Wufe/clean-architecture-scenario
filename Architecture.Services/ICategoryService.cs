using Architecture.Models;
using System.Collections.Generic;

namespace Architecture.Services
{
    public interface ICategoryService
    {
        CategoryBase GetCategoryBase(int id);
        CategoryFull GetCategoryFull(int id);
        IEnumerable<CategoryBase> GetAllCategoriesBase();
        void AddCategory(string title);
        void UpdateCategoryBase(CategoryBase categoryBase);
        void Delete(int id);
    }
}
