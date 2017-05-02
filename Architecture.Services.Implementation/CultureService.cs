using System.Collections.Generic;
using System.Linq;
using Architecture.Models.Common;
using Architecture.Repositories;
using AutoMapper.QueryableExtensions;

namespace Architecture.Services.Implementation
{
    public class CultureService : ICultureService
    {
        private readonly ICultureRepository _cultureRepository;

        public CultureService(
            ICultureRepository cultureRepository
        )
        {
            _cultureRepository = cultureRepository;
        }

        public IEnumerable<CultureBase> GetAllCulturesBase()
        {
            return
                _cultureRepository
                    .GetAll()
                    .ProjectTo<CultureBase>()
                    .ToList();
        }
    }
}
