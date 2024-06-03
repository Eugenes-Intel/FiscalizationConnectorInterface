using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace FiCon.Helpers
{
    public class Serializer
    {
        public static string SerializeToXml<T>(T obj)
        {
            var sw = new StringWriter();
            var xs = new XmlSerializer(typeof(T));
            xs.Serialize(sw, obj);
            return sw.ToString();
        }

        /// <summary>
        /// Enhances interoperability of different data models, but with similar properties. 
        /// It makes objects become compatible with one another through serialization and deserialization
        /// This one takes inn a string of data
        /// </summary>
        /// <typeparam name="T">Destination data model type for which <paramref name="serializedModel"/> is to be deserialized into</typeparam>
        /// <param name="serializedModel">Source data as serialized string model</param>
        /// <returns>A data model of type <typeparamref name="T"/></returns>
        public static async Task<T?> GetDeserializedModelAsync<T>(byte[] data) where T : class
        {
            try
            {
                var serializedModel = Encoding.UTF8.GetString(data);
                return await Task.Run(() => JsonSerializer.Deserialize<T>(serializedModel));
            }
            catch (Exception) { return null; }
        }

        /// <summary>
        /// Enhances interoperability of different data models, but with similar properties. 
        /// It makes objects become compatible with one another through serialization and deserialization
        /// This one takes inn a string of data
        /// </summary>
        /// <typeparam name="T">Destination data model type for which <paramref name="serializedModel"/> is to be deserialized into</typeparam>
        /// <param name="serializedModel">Source data as serialized string model</param>
        /// <returns>A data model of type <typeparamref name="T"/></returns>
        public static async Task<byte[]> GetSerializedBytesAsync<T>(T data) where T : class
        {
            var serializedModel = await Task.Run(() => JsonSerializer.Serialize(data));
            return Encoding.UTF8.GetBytes(serializedModel);
        }
    }
}
