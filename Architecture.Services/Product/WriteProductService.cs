using Architecture.Repositories.Product;
using Architecture.Repositories.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using Architecture.Models.Product;
using AutoMapper;
using System.Linq;

namespace Architecture.Services.Product
{
    public class WriteProductService : IWriteProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;

        public WriteProductService(
            IProductRepository productRepository,
            IProductCategoryRepository productCategoryRepository,
            IMapper mapper
        )
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
        }

        public void AddProduct(string name, string description, double price, int brandId)
        {
            AddProduct(name, description, price, brandId, new List<int>());
        }

        public void AddProduct(string name, string description, double price, int brandId, IEnumerable<int> categoriesIds)
        {
            var product = _productRepository
                .Add(
                    new Database.Entities.Product
                    {
                        BrandId = brandId,
                        Description = description,
                        Name = name,
                        Price = price
                    }
                );
            foreach(int categoryId in categoriesIds)
            {
                _productCategoryRepository
                    .Add(
                        new Database.Entities.ProductCategory
                        {
                            ProductId = product.Id,
                            CategoryId = categoryId
                        }
                    );
            }
            _productRepository.Save();
        }

        public void UpdateProductBase(ProductBase productBase, int selectedBrandId, IEnumerable<int> selectedCategoriesIds)
        {
            var product = _mapper.Map<ProductBase, Database.Entities.Product>(productBase);

            product
                .BrandId = selectedBrandId;

            _productRepository
                .Update(product);

            var toBeDeletedCategoriesLinks = new List<int>();
            var toBeAddedCategoriesLinks = new List<int>();

            var existingProductCategories =
                _productCategoryRepository
                    .GetAll()
                    .Where(x => x.ProductId == productBase.Id)
                    .ToList();

            _DeleteProductCategories(
                _GetToBeDeletedProductCategories(existingProductCategories, selectedCategoriesIds),
                productBase.Id
            );

            _AddProductCategories(
                _GetToBeAddedProductCategories(existingProductCategories, selectedCategoriesIds),
                productBase.Id
            );

            _productRepository
                .Save();
        }

        private void _AddProductCategories(IEnumerable<int> toBeAddedCategoriesLinks, int productId)
        {
            foreach (var categoryId in toBeAddedCategoriesLinks)
            {
                var productCategory = new Database.Entities.ProductCategory
                {
                    CategoryId = categoryId,
                    ProductId = productId
                };
                _productCategoryRepository
                    .Add(productCategory);
            }
        }

        private void _DeleteProductCategories(IEnumerable<int> toBeDeletedCategoriesLinks, int productId)
        {
            foreach (var categoryId in toBeDeletedCategoriesLinks)
            {
                var productCategory =
                    _productCategoryRepository
                        .GetAll()
                        .Where(
                            x => 
                                x.CategoryId == categoryId &&
                                x.ProductId == productId
                        )
                        .FirstOrDefault();
                if (productCategory != null)
                    _productCategoryRepository
                        .Remove(productCategory);
            }
        }

        private IEnumerable<int> _GetToBeDeletedProductCategories(
            IEnumerable<Database.Entities.ProductCategory> existingProductCategories,
            IEnumerable<int> selectedCategoriesIds
        )
        {
            var toBeDeletedCategoriesLinks = new List<int>();
            foreach (var productCategory in existingProductCategories)
            {
                var toDelete =
                    !selectedCategoriesIds
                        .Where(x => x == productCategory.CategoryId)
                        .Any();
                if (toDelete)
                    toBeDeletedCategoriesLinks
                        .Add(productCategory.CategoryId);
            }
            return toBeDeletedCategoriesLinks;
        }

        private IEnumerable<int> _GetToBeAddedProductCategories(
            IEnumerable<Database.Entities.ProductCategory> existingProductCategories,
            IEnumerable<int> selectedCategoriesIds
        )
        {
            var toBeAddedCategoriesLinks = new List<int>();
            foreach (var selectedCategoryId in selectedCategoriesIds)
            {
                var toAdd =
                    !existingProductCategories
                        .Where(x => x.CategoryId == selectedCategoryId)
                        .Any();
                if (toAdd)
                    toBeAddedCategoriesLinks
                        .Add(selectedCategoryId);
            }
            return toBeAddedCategoriesLinks;
        }
    }
}
