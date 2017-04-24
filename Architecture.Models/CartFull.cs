using System.Collections.Generic;

namespace Architecture.Models
{
    public class CartFull
    {
        public int UserId { get; set; }

        public IEnumerable<ProductCart> Products { get; set; }
    }
}
