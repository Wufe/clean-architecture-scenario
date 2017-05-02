using System.ComponentModel.DataAnnotations;

namespace Architecture.Presentation.ViewModels.Category
{
    public class GenericEditCategoryViewModel
    {
        [MinLength(3)]
        public string Title { get; set; }
    }
}
