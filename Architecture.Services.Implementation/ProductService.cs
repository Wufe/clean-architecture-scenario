using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Collections.Generic;
using Architecture.Database.Entities;
using System;
using System.Security.Claims;
using Architecture.Database.Entities.Shared;
using Architecture.Models;
using Architecture.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;

namespace Architecture.Services
{
    public class ProductService : IProductService
    {
        private readonly ICacheService _cache;
        private readonly ILogger<ProductService> _logger;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IProductUserRepository _productUserRepository;
        private readonly IUserService _userService;

        public ProductService(
            ICacheService cache,
            ILogger<ProductService> logger,
            IMapper mapper,
            IProductRepository productRepository,
            IProductCategoryRepository productCategoryRepository,
            IProductUserRepository productUserRepository,
            IUserService userService
        )
        {
            _cache = cache;
            _logger = logger;
            _mapper = mapper;
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _productUserRepository = productUserRepository;
            _userService = userService;
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
                    .ProjectTo<ProductBase>()
                    .FirstOrDefault();
        }

        public ProductFull GetProductFull(int id)
        {
            _logger.LogTrace($"Getting product with id {id}");

            ProductFull foundProduct = null;

            var cacheKey = $"ProdFull:{id}";
            var cachedProduct = _cache.Get<ProductFull>(cacheKey);
            
            if(cachedProduct != null)
            {
                foundProduct = cachedProduct;
            }
            else
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
                foundProduct =
                    products
                        .ProjectTo<ProductFull>()
                        .FirstOrDefault();
                _cache
                    .Set(cacheKey, foundProduct, "ProductFull");
            }

            return foundProduct;
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
                    .ProjectTo<ProductBase>()
                    .ToList();
        }

        public IEnumerable<ProductBase> SearchProductsBase(string searchText)
        {
            searchText = searchText.ToLower();
            var products =
                _productRepository
                    .GetAll();
                    
            products = _productRepository
                    .WithBrand(products);

            products = products
                .Where(
                        x =>
                            x.Name.ToLower().Contains(searchText) ||
                            x.Description.ToLower().Contains(searchText) ||
                            x.Brand.Name.ToLower().Contains(searchText)
                    );
            return
                products
                    .ProjectTo<ProductBase>()
                    .ToList();
        }

        public void AddProduct(string name, string description, double price, int brandId)
        {
            AddProduct(name, description, price, brandId, new List<int>());
        }

        public void AddProduct(string name, string description, double price, int brandId, IEnumerable<int> categoriesIds)
        {
            var categoriesLinks = new List<ProductCategory>();
            foreach (int categoryId in categoriesIds)
            {
                categoriesLinks
                    .Add(
                        new ProductCategory
                        {
                            CategoryId = categoryId
                        }
                    );
            }

            var product = _productRepository
                .Add(
                    new Product
                    {
                        BrandId = brandId,
                        Description = description,
                        Name = name,
                        Price = price,
                        ProductCategories = categoriesLinks
                    }
                );
            
            _productRepository.Save();
        }

        public void UpdateProductBase(ProductBase productBase, int selectedBrandId, IEnumerable<int> selectedCategoriesIds)
        {
            var product = _mapper.Map<ProductBase, Product>(productBase);

            product
                .BrandId = selectedBrandId;

            var existingProductCategories =
                _productCategoryRepository
                    .GetAll()
                    .Where(
                        x =>
                            x.ProductId == productBase.Id
                    )
                    .ToList();

            _DeleteProductCategories(
                _GetToBeDeletedProductCategories(existingProductCategories, selectedCategoriesIds),
                product.Id
            );

            _AddProductCategories(
                _GetToBeAddedProductCategories(existingProductCategories, selectedCategoriesIds),
                product.Id
            );

            _productRepository
                .Update(product);

            _productRepository
                .Save();

            _cache
                .Remove($"ProdFull:{product.Id}");
        }

        private void _AddProductCategories(IEnumerable<int> toBeAddedCategoriesLinks, int productId)
        {
            foreach (var categoryId in toBeAddedCategoriesLinks)
            {
                var productCategory = new ProductCategory
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
                _productCategoryRepository
                    .Remove(productId, categoryId);
                _productCategoryRepository.Save();
            }
        }

        private IEnumerable<int> _GetToBeDeletedProductCategories(
            IEnumerable<ProductCategory> existingProductCategories,
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
            IEnumerable<ProductCategory> existingProductCategories,
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

        public void AddToCart(int productId, int userId, double quantity = 1)
        {
            var cart =
                _productUserRepository
                    .GetAll()
                    .Where(
                        x =>
                            x.ProductId == productId &&
                            x.UserId == userId
                    )
                    .FirstOrDefault();
            if (cart == null)
            {
                _productUserRepository
                    .Add(
                        new ProductUser
                        {
                            ProductId = productId,
                            UserId = userId,
                            Quantity = quantity
                        }
                    );
            }
            else
            {
                cart.Quantity += 1;
                _productUserRepository
                    .Update(cart);
            }
            
            _productUserRepository.Save();
        }

        public void AddToCart(int productId, ClaimsPrincipal userClaim, double quantity = 1)
        {
            var userId =
                _userService
                    .GetUserIdByClaim(userClaim);
            if (userId == default(int))
                throw new UnauthorizedAccessException();
            AddToCart(productId, userId, quantity);
        }

        public void Delete(int id)
        {
            _productRepository
                .Remove(id);
            _productRepository
                .Save();
            _cache
                .Remove($"ProdFull:{id}");
        }

        public IEnumerable<ProductBase> GetMostSeenProductsBase()
        {
            var products =
                _productRepository
                    .GetAll()
                    //.OrderByDescending(x => x.)
                    .Take(10);
            products =
                _productRepository
                    .WithBrand(products);
            return
                products
                    .ProjectTo<ProductBase>()
                    .ToList();
        }
    }
}
