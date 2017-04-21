using Architecture.Models.Product;
using System.Collections.Generic;

namespace Architecture.ViewModels.Cart
{
    public class ShowCartViewModel
    {
        public int UserId { get; set; }

        public IEnumerable<IProductCart> Products { get; set; }
    }
}
