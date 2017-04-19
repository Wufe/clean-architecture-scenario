using Architecture.Models.Brand;
using Architecture.Models.Product;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Mappers.Product
{
    public class ProductBrandResolver : IValueResolver<Database.Entities.Product, Models.Product.IProductMinimal, BrandBase>
    {
        public BrandBase Resolve(Database.Entities.Product source, IProductMinimal destination, BrandBase destMember, ResolutionContext context)
        {
            return new BrandBase
            {
                Id = source.Brand.Id,
                Name = source.Brand.Name
            };
        }
    }
}
