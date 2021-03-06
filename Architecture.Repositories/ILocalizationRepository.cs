﻿using Architecture.Database.Entities;
using Architecture.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Repositories
{
    public interface ILocalizationRepository : IRepository<Localization>
    {
        void Remove(string culture, string key);
    }
}
