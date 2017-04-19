using Architecture.Mappers.Category;
using Architecture.Mappers.Product;
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
            configuration.AddProfile<ProductMappingProfile>();
            configuration.AddProfile<CategoryMappingProfile>();
        }
    }
}
