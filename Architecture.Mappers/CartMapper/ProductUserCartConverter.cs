using Architecture.Database.Entities.Shared;
using Architecture.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Architecture.Mappers.CartMapper
{
    class ProductUserCartConverter : ITypeConverter<IEnumerable<ProductUser>, CartFull>
    {
        public CartFull Convert(IEnumerable<ProductUser> source, CartFull destination, ResolutionContext context)
        {
            if (!source.Any())
                return null;

            var userId =
                source
                    .First()
                    .UserId;

            var productCarts = new List<ProductCart>();

            foreach(var productUser in source)
            {
                var productCart = context.Mapper.Map<ProductUser, ProductCart>(productUser);
                productCarts
                    .Add(productCart);
            }

            return new CartFull
            {
                UserId = userId,
                Products = productCarts
            };
        }
    }
}
