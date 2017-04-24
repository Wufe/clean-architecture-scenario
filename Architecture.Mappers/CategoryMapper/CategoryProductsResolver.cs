using Architecture.Database.Entities;
using Architecture.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Architecture.Mappers.CategoryMapper
{
    public class CategoryProductsResolver : IValueResolver<Category, CategoryFull, IEnumerable<ProductBase>>
    {
        public IEnumerable<ProductBase> Resolve(Category source, CategoryFull destination, IEnumerable<ProductBase> destMember, ResolutionContext context)
        {
            return
                source
                    .ProductCategories
                    .Select(
                        pc =>
                            new ProductBase
                            {
                                Id = pc.Product.Id,
                                Description = pc.Product.Description,
                                Name = pc.Product.Name,
                                Price = pc.Product.Price
                            }
                    );
        }
    }
}
