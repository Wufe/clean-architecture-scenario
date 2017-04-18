using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Models.Product
{
    public class ProductMinimal : ProductBase, IProductMinimal
    {
        public string Brand { get; set; }
    }
}
