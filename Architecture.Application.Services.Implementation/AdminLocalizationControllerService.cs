using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Architecture.Models.Common;
using Architecture.Services;
using Architecture.ViewModels.Controllers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Architecture.Application.Services.Implementation
{
    public class AdminLocalizationControllerService : IAdminLocalizationControllerService
    {
        private readonly ICultureService _cultureService;
        private readonly ILocalizationService _localizationService;

        public AdminLocalizationControllerService(
            ICultureService cultureService,
            ILocalizationService localizationService
        )
        {
            _cultureService = cultureService;
            _localizationService = localizationService;
        }

        public AdminLocalizationIndexViewModel GetIndexViewModel()
        {
            return new AdminLocalizationIndexViewModel()
            {
                AvailableCultures = _GetAvailableCulturesListItems(),
                Value = String.Empty,
                Key = String.Empty,
                SelectedCulture = String.Empty,
                LocalizedStrings = _GetLocalizedStringsFull()
            };
        }

        public AdminLocalizationIndexViewModel GetIndexViewModel(AdminLocalizationIndexViewModel model)
        {
            model.AvailableCultures = _GetAvailableCulturesListItems();
            model.LocalizedStrings = _GetLocalizedStringsFull();
            return model;
        }

        public void AddLocalization(AdminLocalizationIndexViewModel model)
        {
            _localizationService
                .AddLocalization(new LocalizedStringFull()
                {
                    Culture = model.SelectedCulture,
                    Key = model.Key,
                    Value = model.Value
                });
        }

        public void Delete(string culture, string key)
        {
            _localizationService
                .Delete(culture, key);
        }

        private IEnumerable<LocalizedStringFull> _GetLocalizedStringsFull()
        {
            return _localizationService.GetAllLocalizedStringsFull();
        }

        private IEnumerable<SelectListItem> _GetAvailableCulturesListItems()
        {
            return
                _cultureService
                    .GetAllCulturesBase()
                    .Select(x => new SelectListItem()
                    {
                        Value = x.Name,
                        Text = x.Name
                    });
        }
    }
}
