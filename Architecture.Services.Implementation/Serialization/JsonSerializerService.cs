using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Services.Implementation.Serialization
{
    public class JsonSerializerService : ISerializer
    {
        public T Deserialize<T>(string serialized)
        {
            return JsonConvert.DeserializeObject<T>(serialized);
        }

        public string Serialize(object entity)
        {
            return JsonConvert.SerializeObject(entity);
        }
    }
}
