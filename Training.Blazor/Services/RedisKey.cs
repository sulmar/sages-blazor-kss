namespace Training.Blazor.Services;

public class RedisKeys
{
    public static string GetCurrentKey(string user) => $"currentcount:{user}";

}
