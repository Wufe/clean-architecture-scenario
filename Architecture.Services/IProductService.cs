using Architecture.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace Architecture.Services
{
    public interface IProductService
    {
        ProductBase GetProductBase(int id);
        ProductFull GetProductFull(int id);
        IEnumerable<ProductBase> GetAllProductsBase();
        IEnumerable<ProductBase> SearchProductsBase(string searchText);
        void AddProduct(string name, string description, double price, int brandId);
        void AddProduct(string name, string description, double price, int brandId, IEnumerable<int> categoriesIds);
        void UpdateProductBase(ProductBase product, int selectedBrandId, IEnumerable<int> selectedCategoriesIds);
        void AddToCart(int productId, int userId, double quantity = 1);
        void AddToCart(int productId, ClaimsPrincipal userClaim, double quantity = 1);
        void Delete(int id);
        IEnumerable<ProductBase> GetMostSeenProductsBase();
    }
}
