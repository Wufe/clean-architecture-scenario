using Architecture.Models.Product;
using Architecture.Repositories.Product;
using AutoMapper;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Services.Product
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
                        p => _mapper.Map<Database.Entities.Product, ProductMinimal>(p)
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
                        p => _mapper.Map<Database.Entities.Product, ProductFull>(p)
                    )
                    .FirstOrDefault();
        }
    }
}
