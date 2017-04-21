using Architecture.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Models.Cart
{
    public class CartFull : ICartFull
    {
        public int UserId { get; set; }

        public IEnumerable<IProductCart> Products { get; set; }
    }
}
