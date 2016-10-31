using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace webSwagger.Helper
{
    public static class Serializer
    {
        public static string ToJson(object entity)
        {
            var converter = new IsoDateTimeConverter();
            converter.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            var serializer = new JsonSerializer();
            serializer.Converters.Add(converter);
            var sb = new StringBuilder();

            serializer.Serialize(new JsonTextWriter(new StringWriter(sb)), entity);
            return sb.ToString();
        }
    }
}