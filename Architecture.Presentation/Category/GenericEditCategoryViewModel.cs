﻿using System.ComponentModel.DataAnnotations;

namespace Architecture.ViewModels.Category
{
    public class GenericEditCategoryViewModel
    {
        [MinLength(3)]
        public string Title { get; set; }
    }
}
