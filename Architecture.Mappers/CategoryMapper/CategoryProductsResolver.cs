using Architecture.Database.Entities;
using Architecture.Models.Category;
using Architecture.Models.Product;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Architecture.Mappers.CategoryMapper
{
    public class CategoryProductsResolver : IValueResolver<Category, ICategoryFull, IEnumerable<ProductBase>>
    {
        public IEnumerable<ProductBase> Resolve(Category source, ICategoryFull destination, IEnumerable<ProductBase> destMember, ResolutionContext context)
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
