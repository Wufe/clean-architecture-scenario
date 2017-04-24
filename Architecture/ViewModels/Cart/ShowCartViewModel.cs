using Architecture.Models;
using System.Collections.Generic;

namespace Architecture.ViewModels.Cart
{
    public class ShowCartViewModel
    {
        public int UserId { get; set; }

        public IEnumerable<ProductCart> Products { get; set; }
    }
}
