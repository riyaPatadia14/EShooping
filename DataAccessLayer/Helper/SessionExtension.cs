using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;

namespace DataAccessLayer.Helper
{
    public static class SessionExtension
    {
        public static void SetObjectAsJson(this ISession session, string Key, object value)
        {
            session.SetString(Key, JsonConvert.SerializeObject(value));
        }
        public static T GetObjectFromJson<T>(this ISession session, string Key)
        {
            var value = session.GetString(Key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
