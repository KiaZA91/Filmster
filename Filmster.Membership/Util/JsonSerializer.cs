using System;
using System.Text.Json.Serialization;
using System.Text.Json;
using Filmster.Membership2.API.Util;

namespace Filmster.Membership2.API.Util
{
    public static class JsonUtility
    {
        public static T RemoveLoops<T>(T obj)
        {
            var json = JsonSerializer.Serialize(obj, new JsonSerializerOptions()
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            });
            return JsonSerializer.Deserialize<T>(json);
        }
    }

}
