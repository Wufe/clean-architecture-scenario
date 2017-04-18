using System;
using System.Collections.Generic;
using System.Text;
using Architecture.Models.Category;
using Architecture.Repositories.Category;
using System.Linq;
using AutoMapper;

namespace Architecture.Services.Category
{
    public class ReadCategoryService : IReadCategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ReadCategoryService(
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
                    .Select(x => _mapper.Map<Database.Entities.Category, CategoryBase>(x))
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
                    .Select(x => _mapper.Map<Database.Entities.Category, CategoryBase>(x))
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
                    .Select(x => _mapper.Map<Database.Entities.Category, CategoryFull>(x))
                    .FirstOrDefault();
        }
    }
}
