using Architecture.Database.Entities;
using Architecture.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Architecture.Mappers.ProductMapper
{
    public class ProductCategoriesResolver : IValueResolver<Product, ProductFull, IEnumerable<CategoryBase>>
    {
        public IEnumerable<CategoryBase> Resolve(Product source, ProductFull destination, IEnumerable<CategoryBase> destMember, ResolutionContext context)
        {
            return
                source
                    .ProductCategories
                    .Select(
                        pc =>
                            new CategoryBase
                            {
                                Id = pc.Category.Id,
                                Title = pc.Category.Title
                            }
                    );
        }
    }
}
