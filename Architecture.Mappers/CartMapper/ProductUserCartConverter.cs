using Architecture.Database.Entities;
using Architecture.Database.Entities.Shared;
using Architecture.Models.Cart;
using Architecture.Models.Product;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Architecture.Mappers.CartMapper
{
    class ProductUserCartConverter : ITypeConverter<IEnumerable<ProductUser>, ICartFull>
    {
        public ICartFull Convert(IEnumerable<ProductUser> source, ICartFull destination, ResolutionContext context)
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
