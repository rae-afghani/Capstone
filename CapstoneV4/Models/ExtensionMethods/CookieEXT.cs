

using Newtonsoft.Json;

namespace CapstoneV4.Models.ExtensionMethods
{
    /// <summary>
    /// request and response cookies
    /// </summary>
    public static class CookieEXT
    {
        public static string GetCookieString(this IRequestCookieCollection cookies, string key) => cookies[key];

        public static int? GetCookieInt32(this IRequestCookieCollection cookies, string key) => int.TryParse(cookies[key], out int i) ? i : (int?)null;

        public static T GetCookieObj<T>(this IRequestCookieCollection cookies, string key)
        {
            var value = cookies[key];
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }


        //30day int value sets how long cookies are kept
        //deleted old cookies first

        public static void SetCookieString(this IResponseCookies cookies, string key, string value, int days = 30)
        {
            cookies.Delete(key);
            if (days == 0)
                cookies.Append(key, value);
            else
            {
                CookieOptions options = new CookieOptions { Expires = DateTime.Now.AddDays(days) };
                cookies.Append(key, value, options);
            }
        }

        //storing int at strings
        public static void SetCookieInt32(this IResponseCookies cookies, string key, int value, int days = 30) => cookies.SetCookieString(key, value.ToString(), days);

        public static void SetCookieObj<T>(this IResponseCookies cookies, string key, T value, int days = 30) =>
            cookies.SetCookieString(key, JsonConvert.SerializeObject(value), days);

    }
}
