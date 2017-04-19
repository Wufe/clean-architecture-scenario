using Architecture.Models.Category;
using Architecture.Models.Product;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Architecture.Mappers.Category
{
    public class CategoryProductsResolver : IValueResolver<Database.Entities.Category, ICategoryFull, IEnumerable<ProductBase>>
    {
        public IEnumerable<ProductBase> Resolve(Database.Entities.Category source, ICategoryFull destination, IEnumerable<ProductBase> destMember, ResolutionContext context)
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
