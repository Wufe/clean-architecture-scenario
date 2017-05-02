using System;
using System.Collections.Generic;
using System.Text;
using Architecture.ViewModels.Controllers;

namespace Architecture.Application.Services
{
    public interface IAdminLocalizationControllerService
    {
        AdminLocalizationIndexViewModel GetIndexViewModel();
        AdminLocalizationIndexViewModel GetIndexViewModel(AdminLocalizationIndexViewModel model);
        void AddLocalization(AdminLocalizationIndexViewModel model);
        void Delete(string culture, string key);
    }
}
