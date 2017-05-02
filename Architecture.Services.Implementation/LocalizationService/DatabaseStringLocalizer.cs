using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using Architecture.Repositories;
using System.Linq;
using AutoMapper;
using Architecture.Models.Common;
using AutoMapper.QueryableExtensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Architecture.Services.Implementation.LocalizationService
{
    public class DatabaseStringLocalizer<T> : IStringLocalizer<T>
    {
        private readonly ICacheService _cache;
        private readonly IConfigurationRoot _configuration;
        private readonly CultureInfo _culture;
        private readonly ILocalizationRepository _localizationRepository;
        private IMapper _mapper;
        private readonly ILogger<DatabaseStringLocalizer<T>> _logger;

        public DatabaseStringLocalizer(
            ICacheService cache,
            IConfigurationRoot configuration,
            CultureInfo culture,
            ILocalizationRepository localizationRepository,
            ILogger<DatabaseStringLocalizer<T>> logger,
            IMapper mapper
        )
        {
            _cache = cache;
            _configuration = configuration;
            _culture = culture;
            _localizationRepository = localizationRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public DatabaseStringLocalizer(
            ICacheService cache,
            IConfigurationRoot configuration,
            ILocalizationRepository localizationRepository,
            ILogger<DatabaseStringLocalizer<T>> logger,
            IMapper mapper
        )
        {
            _cache = cache;
            _configuration = configuration;
            _culture = CultureInfo.CurrentCulture;
            _localizationRepository = localizationRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public LocalizedString this[string name]
        {
            get
            {
                var cacheKey =
                    $"{_configuration.GetSection("Cache:Localization:Namespace")?.Value}:" +
                    $"{_culture.Name}:" +
                    $"{name}";

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
                            x.Culture.Equals(_culture.Name) &&
                            x.Key.Equals(name)
                    )
                    .Select(x => new LocalizedString(x.Key, x.Value))
                    .FirstOrDefault();

                if (savedString == null)
                {
                    _logger.LogWarning(
                        $"Cannot find cache key <{cacheKey}> " +
                        $"corresponding to the localization key <{name}> " +
                        $"for culture <{_culture.Name}>." +
                        $"The cache will be populated with a temporary string " +
                        $"till a correct localization is submitted.");
                    savedString = new LocalizedString(name, name, true);
                }
                _cache.Set(cacheKey, _mapper.Map<LocalizedString, LocalizedStringBase>(savedString), "LocalizedString");
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
                    .Where(x => x.Culture.Equals(_culture.Name))
                    .ProjectTo<LocalizedString>()
                    .ToList();
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            return new DatabaseStringLocalizer<T>(_cache, _configuration, culture, _localizationRepository, _logger, _mapper);
        }
    }
}
