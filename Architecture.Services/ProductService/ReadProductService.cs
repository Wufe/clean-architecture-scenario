using Architecture.Models.Product;
using Architecture.Repositories.Product;
using AutoMapper;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Architecture.Database.Entities;

namespace Architecture.Services.ProductService
{
    public class ReadProductService : IReadProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ReadProductService(
            IProductRepository productRepository,
            IMapper mapper
        )
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public ProductBase GetProductBase(int id)
        {
            var products =
                _productRepository
                    .GetAll()
                    .Where(p => p.Id == id);
            products = _productRepository
                    .WithBrand(products);
            return
                products
                    .Select(
                        p => _mapper.Map<Product, ProductBase>(p)
                    )
                    .FirstOrDefault();
        }

        public ProductMinimal GetProductMinimal(int id)
        {
            var products =
                _productRepository
                    .GetAll()
                    .Where(p => p.Id == id);
            products = _productRepository
                    .WithBrand(products);
            return
                products
                    .Select(
                        p => _mapper.Map<Product, ProductMinimal>(p)
                    )
                    .FirstOrDefault();
        }

        public ProductFull GetProductFull(int id)
        {
            var products =
                _productRepository
                    .GetAll()
                    .Where(p => p.Id == id);
            products =
                _productRepository
                    .WithBrand(products);
            products =
                _productRepository
                    .WithCategories(products);
            products =
                _productRepository
                    .WithRatings(products);
            return
                products
                    .Select(
                        p => _mapper.Map<Product, ProductFull>(p)
                    )
                    .FirstOrDefault();
        }

        public IEnumerable<ProductBase> GetAllProductsBase()
        {
            var products =
                _productRepository
                    .GetAll();
            products = _productRepository
                    .WithBrand(products);
            return
                products
                    .Select(
                        p => _mapper.Map<Product, ProductBase>(p)
                    )
                    .ToList();
        }

        public IEnumerable<ProductMinimal> GetAllProductsMinimal()
        {
            var products =
                _productRepository
                    .GetAll();
            products = _productRepository
                    .WithBrand(products);
            return
                products
                    .Select(
                        p => _mapper.Map<Product, ProductMinimal>(p)
                    )
                    .ToList();
        }

        public IEnumerable<ProductMinimal> SearchProductsMinimal(string searchText)
        {
            var products =
                _productRepository
                    .GetAll();
                    
            products = _productRepository
                    .WithBrand(products);

            products = products
                .Where(
                        x =>
                            x.Name.Contains(searchText) ||
                            x.Description.Contains(searchText) ||
                            x.Brand.Name.Contains(searchText)
                    );
            return
                products
                    .Select(
                        p => _mapper.Map<Product, ProductMinimal>(p)
                    )
                    .ToList();
        }
    }
}
