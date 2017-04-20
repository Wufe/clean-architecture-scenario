using Architecture.Models.Product;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Architecture.Services.ProductService
{
    public interface IReadProductService
    {
        ProductBase GetProductBase(int id);

        ProductMinimal GetProductMinimal(int id);

        ProductFull GetProductFull(int id);

        IEnumerable<ProductBase> GetAllProductsBase();

        IEnumerable<ProductMinimal> GetAllProductsMinimal();

        IEnumerable<ProductMinimal> SearchProductsMinimal(string searchText);

        IEnumerable<ProductBase> GetAllProductsInCart(int userId);

        IEnumerable<ProductBase> GetAllProductsInCart(ClaimsPrincipal userClaim);
    }
}
