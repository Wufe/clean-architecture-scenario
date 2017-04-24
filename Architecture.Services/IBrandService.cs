using Architecture.Models;
using System.Collections.Generic;

namespace Architecture.Services
{
    public interface IBrandService
    {
        IEnumerable<BrandBase> GetAllBrandsBase();
    }
}
