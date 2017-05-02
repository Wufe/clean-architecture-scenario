using Architecture.Models.Common;
using Architecture.Repositories;
using Architecture.Services;
using AutoMapper.QueryableExtensions;
using Microsoft.Extensions.Logging;
using System.Linq;
using Architecture.Database.Entities;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace Architecture.Cache
{
    /// <summary>
    /// Populates the cache with the localized strings.
    /// </summary>
    public class LocalizationCache
    {
        private readonly ILocalizationRepository _localizationRepository;
        private readonly ICacheService _cacheService;
        private readonly IConfigurationRoot _configuration;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public LocalizationCache(
            ICacheService cacheService,
            IConfigurationRoot configuration,
            ILocalizationRepository localizationRepository,
            ILogger<LocalizationCache> logger,
            IMapper mapper
        )
        {
            _cacheService = cacheService;
            _configuration = configuration;
            _localizationRepository = localizationRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public void Populate()
        {
            var localizedStrings =
                _localizationRepository
                    .GetAll()
                    .ToList();
            foreach(var localizedString in localizedStrings)
            {
                var cacheKey =
                    $"{_configuration.GetSection("Cache:Localization:Namespace")?.Value}:" +
                    $"{localizedString.Culture}:" +
                    $"{localizedString.Key}";

                _logger.LogInformation($"Cache: populating <{cacheKey}>");

                var localizedStringBase = _mapper.Map<Localization, LocalizedStringBase>(localizedString);
                _cacheService
                    .Set(cacheKey, localizedStringBase, "LocalizedString");
            }
        }
    }
}
