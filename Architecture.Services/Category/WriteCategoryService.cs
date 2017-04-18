using Architecture.Repositories.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Services.Category
{
    public class WriteCategoryService : IWriteCategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public WriteCategoryService(
            ICategoryRepository categoryRepository
        )
        {
            _categoryRepository = categoryRepository;
        }
        public void AddCategory(string title)
        {
            _categoryRepository
                .Add(
                    new Database.Entities.Category
                    {
                        Title = title
                    }
                );
            _categoryRepository.Save();
        }
    }
}
