using Architecture.Models;
using System.Collections.Generic;

namespace Architecture.Presentation.ViewModels.Category
{
    public class ListCategoriesViewModel
    {
        public IEnumerable<CategoryBase> Categories { get; set; } = new List<CategoryBase>();
    }
}
