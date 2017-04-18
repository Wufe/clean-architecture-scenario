using Architecture.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Models.Category
{
    public interface ICategoryFull : ICategoryBase
    {
        IEnumerable<ProductBase> Products { get; set; }
    }
}
