using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace FuelEfficiency.Models
{
    public static class TempDataChanger
    {
        /// <summary>
        /// takes the tempData turns into a JSON string
        /// </summary>
        /// <typeparam name="TempParameters"></typeparam>
        /// <param name="tempData"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Put<TempParameter>(this ITempDataDictionary tempData, string key, TempParameter value) where TempParameter : class
        {
            tempData[key] = JsonSerializer.Serialize(value);
        }

        /// <summary>
        /// takes the JSON string turns into a tempData
        /// </summary>
        /// <typeparam name="TempParameter"></typeparam>
        /// <param name="tempData"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static TempParameter Get<TempParameter>(this ITempDataDictionary tempData, string key) where TempParameter : class
        {
            tempData.TryGetValue(key, out object objectInfo);
            return objectInfo == null ? null : JsonSerializer.Deserialize<TempParameter>((string)objectInfo);
        }

        /// <summary>
        /// Peek calls tempData key
        /// </summary>
        /// <typeparam name="TempParameter"></typeparam>
        /// <param name="tempData"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static TempParameter Peek<TempParameter>(this ITempDataDictionary tempData, string key) where TempParameter : class
        {
            object objectInfo = tempData.Peek(key);
            return objectInfo == null ? null : JsonSerializer.Deserialize<TempParameter>((string)objectInfo);
        }
    }
}
