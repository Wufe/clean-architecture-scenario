using Architecture.Models.Product;
using System.Collections.Generic;

namespace Architecture.Models.Category
{
    public class CategoryFull : CategoryBase, ICategoryFull
    {
        public IEnumerable<ProductBase> Products { get; set; } = new List<ProductBase>();
    }
}
