using Architecture.Models.Interfaces;
using Architecture.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Models.Cart
{
    public interface ICartFull
    {
        int UserId { get; set; }

        IEnumerable<IProductCart> Products { get; set; }
    }
}
