using System;
using System.Collections.Generic;
using System.Text;
using Architecture.Models.Category;
using Architecture.Repositories.Category;
using System.Linq;
using AutoMapper;
using Architecture.Database.Entities;

namespace Architecture.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(
            ICategoryRepository categoryRepository,
            IMapper mapper
        )
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public IEnumerable<CategoryBase> GetAllCategoriesBase()
        {
            return
                _categoryRepository
                    .GetAll()
                    .Select(x => _mapper.Map<Category, CategoryBase>(x))
                    .ToList();
        }

        public CategoryBase GetCategoryBase(int id)
        {
            var categories =
                _categoryRepository
                    .GetAll()
                    .Where(x => x.Id == id);
            categories =
                _categoryRepository
                    .WithProducts(categories);
            return
                categories
                    .Select(x => _mapper.Map<Category, CategoryBase>(x))
                    .FirstOrDefault();
        }

        public CategoryFull GetCategoryFull(int id)
        {
            var categories =
                _categoryRepository
                    .GetAll()
                    .Where(x => x.Id == id);
            categories =
                _categoryRepository
                    .WithProducts(categories);
            return
                categories
                    .Select(x => _mapper.Map<Category, CategoryFull>(x))
                    .FirstOrDefault();
        }

        public void AddCategory(string title)
        {
            _categoryRepository
                .Add(
                    new Category
                    {
                        Title = title
                    }
                );
            _categoryRepository.Save();
        }

        public void UpdateCategoryBase(CategoryBase categoryBase)
        {
            var category = _mapper.Map<CategoryBase, Category>(categoryBase);
            _categoryRepository
                .Update(category);
            _categoryRepository.Save();
        }
    }
}
