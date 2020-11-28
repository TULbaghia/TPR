using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace Serializer
{
    public class JsonSerializer
    {

        private readonly static JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            PreserveReferencesHandling = PreserveReferencesHandling.All,
        };

        public static void Serialize(Object obj, string filePath)
        {
            File.Delete(filePath);
            using FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
            string serialized = JsonConvert.SerializeObject(obj, Formatting.Indented, JsonSerializer.JsonSettings);
            fs.Write(Encoding.UTF8.GetBytes(serialized));
            fs.Flush();
        }

        public static T Deserialize<T>(string filePath)
        {
            using FileStream fs = new FileStream(filePath, FileMode.Open);
            byte[] bytes = new byte[fs.Length];
            fs.Read(bytes);
            return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(bytes), JsonSerializer.JsonSettings);
        }

    }
}
