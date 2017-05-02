using Architecture.Mappers.BrandMapper;
using Architecture.Mappers.CartMapper;
using Architecture.Mappers.CategoryMapper;
using Architecture.Mappers.CultureMapper;
using Architecture.Mappers.LocalizationMapper;
using Architecture.Mappers.ProductMapper;
using Architecture.Mappers.ProductUserMapper;
using Architecture.Mappers.RatingMapper;
using Architecture.Mappers.UserMapper;
using AutoMapper;

namespace Architecture.Mappers.Common
{
    public class MappingConfiguration
    {
        public static void Configure(
            IMapperConfigurationExpression configuration
        )
        {
            configuration.AddProfile<BrandMappingProfile>();
            configuration.AddProfile<CartMappingProfile>();
            configuration.AddProfile<CategoryMappingProfile>();
            configuration.AddProfile<CultureMappingProfile>();
            configuration.AddProfile<LocalizationMappingProfile>();
            configuration.AddProfile<ProductMappingProfile>();
            configuration.AddProfile<ProductUserMappingProfile>();
            configuration.AddProfile<RatingMappingProfile>();
            configuration.AddProfile<UserMappingProfile>();
        }
    }
}
