using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Architecture.Models;

namespace Architecture.ViewModels.Product
{
    public class ListProductsViewModel
    {
        public IEnumerable<ProductBase> Products { get; set; } = new List<ProductBase>();

        [MinLength(3)]
        public string SearchText { get; set; }
    }
}
