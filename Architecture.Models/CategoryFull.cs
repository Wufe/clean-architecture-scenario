using System.Collections.Generic;

namespace Architecture.Models
{
    public class CategoryFull : CategoryBase
    {
        public IEnumerable<ProductBase> Products { get; set; } = new List<ProductBase>();
    }
}
