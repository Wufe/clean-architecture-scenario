using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Models.Product
{
    public class ProductCart : ProductBase, IProductCart
    {
        public double Quantity { get; set; }
    }
}
