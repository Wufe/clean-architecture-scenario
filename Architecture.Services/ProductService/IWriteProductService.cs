using Architecture.Models.Product;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Architecture.Services.ProductService
{
    public interface IWriteProductService
    {
        void AddProduct(string name, string description, double price, int brandId);
        void AddProduct(string name, string description, double price, int brandId, IEnumerable<int> categoriesIds);
        void UpdateProductBase(ProductBase product, int selectedBrandId, IEnumerable<int> selectedCategoriesIds);
        void AddToCart(int productId, int userId, double quantity = 1);
        void AddToCart(int productId, ClaimsPrincipal userClaim, double quantity = 1);
    }
}
