using Architecture.Models.Common;
using Architecture.Repositories;
using Architecture.Services;
using AutoMapper.QueryableExtensions;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Architecture.Cache
{
    public class LocalizationCache
    {
        private readonly ILocalizationRepository _localizationRepository;
        private readonly ICacheService _cacheService;
        private readonly ILogger _logger;

        public LocalizationCache(
            ICacheService cacheService,
            ILocalizationRepository localizationRepository,
            ILogger<LocalizationCache> logger
        )
        {
            _cacheService = cacheService;
            _localizationRepository = localizationRepository;
            _logger = logger;
        }

        public void Populate()
        {
            var localizedStrings =
                _localizationRepository
                    .GetAll()
                    .ProjectTo<LocalizedStringBase>()
                    .ToList();
            foreach(var localizedString in localizedStrings)
            {
                var cacheKey = $"Localization.{localizedString.Key}";

                _logger.LogInformation($"Cache: populating <{cacheKey}>");

                _cacheService
                    .Set(cacheKey, localizedString, "LocalizedString");
            }
        }
    }
}
