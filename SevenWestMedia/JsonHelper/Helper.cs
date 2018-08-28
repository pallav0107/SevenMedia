using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Text;

namespace JsonHelper
{
    /// <summary>
    /// Person data object
    /// </summary>
    public partial class Person
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("first")]
        public string First { get; set; }

        [JsonProperty("last")]
        public string Last { get; set; }

        [JsonProperty("age")]
        public long Age { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }
    }

    /// <summary>
    /// Partial class with deserialize method
    /// </summary>
    public partial class Person
    {
        /// <summary>
        /// Deserialize object
        /// </summary>
        /// <param name="json"> Json string </param>
        /// <returns> Returns list of person objects </returns>
        public static List<Person> FromJson(string json) => JsonConvert.DeserializeObject<List<Person>>(json, JsonHelper.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    public static class Helper
    {
        /// <summary>
        /// Converts Json to object
        /// </summary>
        /// <returns></returns>
        public static List<Person> ReadJson()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"example_data.json");
            List<Person> result = new List<Person>();

            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                result = JsonHelper.Person.FromJson(json);

            }
            return result;
        }
    }
}
