using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Architecture.Models.Common;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Architecture.ViewModels.Controllers
{
    public class AdminLocalizationIndexViewModel
    {
        public IEnumerable<LocalizedStringFull> LocalizedStrings { get; set; } = new List<LocalizedStringFull>();

        [Required]
        [MinLength(1)]
        public string Key { get; set; }

        [Required]
        [MinLength(1)]
        public string Value { get; set; }

        public string SelectedCulture { get; set; }

        public IEnumerable<SelectListItem> AvailableCultures { get; set; } = new List<SelectListItem>();
    }
}
