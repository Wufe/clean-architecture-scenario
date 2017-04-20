using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Services.CategoryService
{
    public interface ICategoryService : IReadCategoryService, IWriteCategoryService
    {
    }
}
