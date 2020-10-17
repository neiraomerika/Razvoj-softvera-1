using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arena.Web.Helper
{
    public static class MySessionExtensions
    {
        public static void Set<T>(this ISession ssesion,string key,T value)
        {
            ssesion.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession ssesion,string key)
        {
            var value = ssesion.GetString(key);
            return value == null ? default(T) :
                JsonConvert.DeserializeObject<T>(value);
        }
    }
}
