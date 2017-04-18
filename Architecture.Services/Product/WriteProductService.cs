using Architecture.Repositories.Product;
using Architecture.Repositories.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Services.Product
{
    public class WriteProductService : IWriteProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public WriteProductService(
            IProductRepository productRepository,
            IProductCategoryRepository productCategoryRepository
        )
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
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
    }
}
