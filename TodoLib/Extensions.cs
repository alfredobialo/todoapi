using Newtonsoft.Json;

namespace TodoLib;

public static class Extensions
{
    public static string ToJson(this object obj, bool format = false)
    {
        return JsonConvert.SerializeObject(obj, format ? Formatting.Indented : Formatting.None);
    }

    public static T? FromJson<T>(this string obj)
    {
        return JsonConvert.DeserializeObject<T>(obj);
    }
}
