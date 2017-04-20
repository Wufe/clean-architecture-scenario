using Architecture.Models.Product;
using Architecture.Repositories.Product;
using AutoMapper;
using System.Linq;
using System.Collections.Generic;
using Architecture.Database.Entities;
using Architecture.Repositories.Shared;
using Architecture.Repositories.Cart;
using System;
using Architecture.Services.UserService;
using System.Security.Claims;

namespace Architecture.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IUserService _userService;

        public ProductService(
            IMapper mapper,
            ICartRepository cartRepository,
            IProductRepository productRepository,
            IProductCategoryRepository productCategoryRepository,
            IUserService userService
        )
        {
            _mapper = mapper;
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
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

        public void AddProduct(string name, string description, double price, int brandId)
        {
            AddProduct(name, description, price, brandId, new List<int>());
        }

        public void AddProduct(string name, string description, double price, int brandId, IEnumerable<int> categoriesIds)
        {
            var product = _productRepository
                .Add(
                    new Product
                    {
                        BrandId = brandId,
                        Description = description,
                        Name = name,
                        Price = price
                    }
                );
            foreach (int categoryId in categoriesIds)
            {
                _productCategoryRepository
                    .Add(
                        new ProductCategory
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
            var product = _mapper.Map<ProductBase, Product>(productBase);

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
                _cartRepository
                    .GetAll()
                    .Where(
                        x =>
                            x.ProductId == productId &&
                            x.UserId == userId
                    )
                    .FirstOrDefault();
            if (cart == null)
            {
                _cartRepository
                    .Add(
                        new Cart
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
                _cartRepository
                    .Update(cart);
            }
            
            _cartRepository.Save();
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

        public IEnumerable<ProductFull> GetAllProductsInCart(int userId)
        {
            var carts =
                _cartRepository
                    .GetAll()
                    .Where(
                        x =>
                            x.UserId == userId
                    );
            carts =
                _cartRepository
                    .WithProducts(carts);

            // TODO: Continue from here
            return
                carts
                    .ToList()
                    .Select(x => Mapper.Map<Cart, CartBase>(x));
                
        }

        public IEnumerable<ProductFull> GetAllProductsInCart(ClaimsPrincipal userClaim)
        {
            var userId =
                _userService
                    .GetUserIdByClaim(userClaim);
            if (userId == default(int))
                throw new ArgumentNullException("ClaimsPrincipal");
            return GetAllProductsInCart(userId);
        }
        
    }
}
