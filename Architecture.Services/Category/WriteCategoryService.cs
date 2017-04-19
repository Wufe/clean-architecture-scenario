using Architecture.Models.Category;
using Architecture.Repositories.Category;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Services.Category
{
    public class WriteCategoryService : IWriteCategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public WriteCategoryService(
            ICategoryRepository categoryRepository,
            IMapper mapper
        )
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
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

        public void UpdateCategoryBase(CategoryBase categoryBase)
        {
            var category = _mapper.Map<CategoryBase, Database.Entities.Category>(categoryBase);
            _categoryRepository
                .Update(category);
            _categoryRepository.Save();
        }
    }
}
