using Architecture.Models.Product;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Mappers.Product
{
    public class ProductBrandResolver : IValueResolver<Database.Entities.Product, Models.Product.IProductMinimal, string>
    {
        public string Resolve(Database.Entities.Product source, IProductMinimal destination, string destMember, ResolutionContext context)
        {
            return source
                .Brand?
                .Name;
        }
    }
}
