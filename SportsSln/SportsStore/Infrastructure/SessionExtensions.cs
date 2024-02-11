using System.Text.Json;

namespace SportsStore.Infrastructure
{
    public static class SessionExtensions
    {
        // Serialize objects into JavaScript Object Notation format, making it easy to store and retrieve
        // cart objects.
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T? GetJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
        }
    }
}
