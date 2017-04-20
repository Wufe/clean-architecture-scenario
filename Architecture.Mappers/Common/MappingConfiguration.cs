using Architecture.Mappers.BrandMapper;
using Architecture.Mappers.CategoryMapper;
using Architecture.Mappers.ProductMapper;
using Architecture.Mappers.RatingMapper;
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
            configuration.AddProfile<ProductMappingProfile>();
            configuration.AddProfile<CategoryMappingProfile>();
            configuration.AddProfile<RatingMappingProfile>();
        }
    }
}
