using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Services.ProductService
{
    public interface IProductService : IReadProductService, IWriteProductService
    {
    }
}
