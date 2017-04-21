using Architecture.Database.Entities.Shared;
using Architecture.Models.Cart;
using AutoMapper;
using System.Collections.Generic;

namespace Architecture.Mappers.CartMapper
{
    public class CartMappingProfile : Profile
    {
        public CartMappingProfile()
        {
            CreateMap<IEnumerable<ProductUser>, ICartFull>()
                .ConvertUsing<ProductUserCartConverter>();
        }
    }
}
