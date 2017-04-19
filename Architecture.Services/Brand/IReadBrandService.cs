using Architecture.Models.Brand;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Services.Brand
{
    public interface IReadBrandService
    {
        IEnumerable<BrandBase> GetAllBrandsBase();
    }
}
