using Architecture.Models.Category;
using Architecture.Models.Product;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Architecture.Mappers.Product
{
    public class ProductCategoriesResolver : IValueResolver<Database.Entities.Product, IProductFull, IEnumerable<CategoryBase>>
    {
        public IEnumerable<CategoryBase> Resolve(Database.Entities.Product source, IProductFull destination, IEnumerable<CategoryBase> destMember, ResolutionContext context)
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
