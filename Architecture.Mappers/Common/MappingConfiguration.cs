using Architecture.Mappers.Brand;
using Architecture.Mappers.Category;
using Architecture.Mappers.Product;
using Architecture.Mappers.Rating;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

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
