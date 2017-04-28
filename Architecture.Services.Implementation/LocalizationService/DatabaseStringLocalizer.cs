using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using Architecture.Repositories;
using System.Linq;
using AutoMapper;
using Architecture.Models.Common;
using AutoMapper.QueryableExtensions;

namespace Architecture.Services.Implementation.LocalizationService
{
    public class DatabaseStringLocalizer<T> : IStringLocalizer<T>
    {
        private readonly CultureInfo _culture;
        private readonly ILocalizationRepository _localizationRepository;
        private readonly ICacheService _cache;
        private IMapper _mapper;

        public DatabaseStringLocalizer(
            ICacheService cache,
            CultureInfo culture,
            ILocalizationRepository localizationRepository,
            IMapper mapper
        )
        {
            _cache = cache;
            _culture = culture;
            _localizationRepository = localizationRepository;
            _mapper = mapper;
        }

        public DatabaseStringLocalizer(
            ICacheService cache,
            ILocalizationRepository localizationRepository,
            IMapper mapper
        )
        {
            _cache = cache;
            _culture = CultureInfo.CurrentCulture;
            _localizationRepository = localizationRepository;
            _mapper = mapper;
        }

        public LocalizedString this[string name]
        {
            get
            {
                var cacheKey = $"Localization.{name}";

                LocalizedStringBase cachedString = 
                    _cache
                        .Get<LocalizedStringBase>(cacheKey);

                if (cachedString != null)
                    return _mapper.Map<LocalizedStringBase, LocalizedString>(cachedString);

                LocalizedString savedString =
                    _localizationRepository
                    .GetAll()
                    .Where(
                        x =>
                            x.Culture.Equals(_culture.TwoLetterISOLanguageName) &&
                            x.Key.Equals(name)
                    )
                    .Select(x => new LocalizedString(x.Key, x.Value, false))
                    .FirstOrDefault();

                if (savedString != null)
                {
                    _cache.Set(cacheKey, _mapper.Map<LocalizedString, LocalizedStringBase>(savedString), "LocalizedString");
                }
                else
                {
                    savedString = new LocalizedString(name, name, true);
                }
                return savedString;    
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
                    .ProjectTo<LocalizedString>()
                    .ToList();
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            return new DatabaseStringLocalizer<T>(_cache, culture, _localizationRepository, _mapper);
        }
    }
}
