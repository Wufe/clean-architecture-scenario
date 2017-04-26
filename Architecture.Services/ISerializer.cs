using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Services
{
    public interface ISerializer
    {
        string Serialize(object entity);
        T Deserialize<T>(string serialized);
    }
}
