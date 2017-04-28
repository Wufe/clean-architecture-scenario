using Microsoft.AspNetCore.Mvc.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace Architecture.Services.Implementation.LocalizationService
{
    class DatabaseViewLocalizer : IViewLocalizer
    {
        public LocalizedHtmlString this[string name] => throw new NotImplementedException();

        public LocalizedHtmlString this[string name, params object[] arguments] => throw new NotImplementedException();

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            throw new NotImplementedException();
        }

        public LocalizedString GetString(string name)
        {
            throw new NotImplementedException();
        }

        public LocalizedString GetString(string name, params object[] arguments)
        {
            throw new NotImplementedException();
        }

        public IHtmlLocalizer WithCulture(CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
