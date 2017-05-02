using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Architecture.Database.Entities;
using Architecture.Models.Common;
using Architecture.Repositories;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace Architecture.Services.Implementation.LocalizationService
{
    public class LocalizationService : ILocalizationService
    {
        private readonly ICacheService _cache;
        private readonly IConfigurationRoot _configuration;
        private readonly ILocalizationRepository _localizationRepository;
        private readonly IMapper _mapper;

        public LocalizationService(
            ICacheService cache,
            IConfigurationRoot configuration,
            ILocalizationRepository localizationRepository,
            IMapper mapper
        )
        {
            _cache = cache;
            _configuration = configuration;
            _localizationRepository = localizationRepository;
            _mapper = mapper;
        }

        public IEnumerable<LocalizedStringFull> GetAllLocalizedStringsFull()
        {
            return
                _localizationRepository
                    .GetAll()
                    .ProjectTo<LocalizedStringFull>()
                    .ToList();
        }

        public void AddLocalization(LocalizedStringFull localizedString)
        {
            _localizationRepository
                .Add(
                    _mapper.Map<LocalizedStringFull, Localization>(localizedString)
                );
            _localizationRepository
                .Save();

            var cacheKey = _GetCacheKey(localizedString.Culture, localizedString.Key);
            _cache
                .Remove(cacheKey);
        }

        public void Delete(string culture, string key)
        {
            _localizationRepository
                .Remove(culture, key);
            _localizationRepository
                .Save();

            var cacheKey = _GetCacheKey(culture, key);
            _cache
                .Remove(cacheKey);
        }

        private string _GetCacheKey(string culture, string key)
        {
            return
                $"{_configuration.GetSection("Cache:Localization:Namespace")?.Value}:" +
                $"{culture}:" +
                $"{key}";
        }
    }
}
