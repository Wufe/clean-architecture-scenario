using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Architecture.Database.Entities;
using Architecture.Models;
using Architecture.Repositories;

namespace Architecture.Services
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
                    .ProjectTo<CategoryBase>()
                    .ToList();
        }

        public CategoryBase GetCategoryBase(int id)
        {
            var categories =
                _categoryRepository
                    .GetAll();
            categories =
                _categoryRepository
                    .WithProducts(categories);
            return
                categories
                    .ProjectTo<CategoryBase>()
                    .SingleOrDefault(x => x.Id == id);
        }

        public CategoryFull GetCategoryFull(int id)
        {
            var categories =
                _categoryRepository
                    .GetAll();
            categories =
                _categoryRepository
                    .WithProducts(categories);
            return
                categories
                    .ProjectTo<CategoryFull>()
                    .SingleOrDefault(x => x.Id == id);
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

        public void Delete(int id)
        {
            _categoryRepository
                .Remove(id);
            _categoryRepository
                .Save();
        }
    }
}
