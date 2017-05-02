using System.Collections.Generic;
using Architecture.Models;

namespace Architecture.ViewModels.Cart
{
    public class ShowCartViewModel
    {
        public int UserId { get; set; }

        public IEnumerable<ProductCart> Products { get; set; }
    }
}
