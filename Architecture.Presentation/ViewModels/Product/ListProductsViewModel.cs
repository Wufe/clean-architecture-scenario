using Architecture.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Architecture.Presentation.ViewModels.Product
{
    public class ListProductsViewModel
    {
        public IEnumerable<ProductBase> Products { get; set; } = new List<ProductBase>();

        [MinLength(3)]
        public string SearchText { get; set; }
    }
}
