using System.Collections.Generic;
using Architecture.Models.Common;

namespace Architecture.Services
{
    public interface ICultureService
    {
        IEnumerable<CultureBase> GetAllCulturesBase();
    }
}
