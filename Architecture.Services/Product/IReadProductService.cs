using Architecture.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Services.Product
{
    public interface IReadProductService
    {
        ProductMinimal GetProductMinimal(int id);

        ProductFull GetProductFull(int id);
    }
}
