using Newtonsoft.Json;

namespace CapstoneV4.Models.ExtensionMethods

{
    public static class SessionEXT
    {
        public static void SetObj<T>(this ISession session, string key, T value) => session.SetString(key, JsonConvert.SerializeObject(value));

        public static T GetObj<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            if (value == null)
            {
                return default(T);
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
        }

    }
}
