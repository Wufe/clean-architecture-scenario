using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Architecture.Repositories;
using System.Linq;
using AutoMapper.QueryableExtensions;

namespace Architecture.Services.Implementation.LocalizationService
{
    public class DatabaseStringLocalizer<T> : IStringLocalizer<T>
    {
        private readonly CultureInfo _culture;
        private readonly ILocalizationRepository _localizationRepository;

        public DatabaseStringLocalizer(
            CultureInfo culture,
            ILocalizationRepository localizationRepository
        )
        {
            _culture = culture;
            _localizationRepository = localizationRepository;
        }

        public DatabaseStringLocalizer(ILocalizationRepository localizationRepository)
        {
            _culture = CultureInfo.CurrentCulture;
            _localizationRepository = localizationRepository;
        }

        public LocalizedString this[string name]
        {
            get
            {
                return
                    _localizationRepository
                        .GetAll()
                        .Where(x => x.Culture.Equals(_culture.TwoLetterISOLanguageName))
                        .Select(x => new LocalizedString(x.Key, x.Value))
                        .FirstOrDefault()
                    ?? new LocalizedString(name, name, true);
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var localizedString = this[name];
                return 
                    new LocalizedString(
                        name: name,
                        value: String.Format(
                            localizedString.Value,
                            arguments
                        )
                    );
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            return
                _localizationRepository
                    .GetAll()
                    .Where(x => x.Culture.Equals(_culture.TwoLetterISOLanguageName))
                    .Select(x => new LocalizedString(x.Key, x.Value))
                    .ToList();
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            return new DatabaseStringLocalizer<T>(culture, _localizationRepository);
        }
    }
}
