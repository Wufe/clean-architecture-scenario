using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Models.Product
{
    /// <summary>
    /// Represents a product in a cart
    /// </summary>
    public interface IProductCart : IProductBase
    {
        double Quantity { get; set; }
    }
}
