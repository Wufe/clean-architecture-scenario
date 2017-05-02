using System;
using System.Collections.Generic;
using System.Text;
using Architecture.Models.Common;

namespace Architecture.Services
{
    public interface ILocalizationService
    {
        IEnumerable<LocalizedStringFull> GetAllLocalizedStringsFull();
        void AddLocalization(LocalizedStringFull localizedString);
        void Delete(string culture, string key);
    }
}
