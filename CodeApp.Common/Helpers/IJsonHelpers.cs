﻿using Newtonsoft.Json;

namespace CodeApp.Common.Helpers
{
    public interface IJsonHelpers<T>
    {
        T GetJsonObject(string json);
        string GetJsonString(T obj);
    }

    public class JsonHelpers<T> : IJsonHelpers<T>

    {
        public T GetJsonObject(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        public string GetJsonString(T obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
    }
}