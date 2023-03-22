using System.Collections.Specialized;

namespace RickAndMorty.Api.Helpers;

public static class HttpHelper
{
    public static string ToQueryString(NameValueCollection collection)
    {
        var array = (from key in collection.AllKeys
                from value in collection.GetValues(key)
                select $"{Uri.EscapeDataString(key)}={Uri.EscapeDataString(value)}")
            .ToArray();
        return "?" + string.Join("&", array);
    }
}