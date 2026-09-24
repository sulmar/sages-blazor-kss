namespace Training.Blazor.Services;

public class RedisKeys
{
    // Klucz licznika w Redis, osobny dla użytkownika.
    public static string GetCurrentKey(string user) => $"currentcount:{user}";
}
