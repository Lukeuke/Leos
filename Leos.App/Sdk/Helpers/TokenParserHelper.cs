namespace Leos.App.Sdk.Helpers;

public static class TokenParserHelper
{
    public static T Shift<T>(this List<T> l)
    {
        var item = l[0];
        l.Remove(item);
        return item;
    }

    public static bool IsAlphabetic(this string value)
    {
        return value.ToUpper() != value.ToLower();
    }

    public static bool CanSkip(this string value)
    {
        return value[0] == ' ' || value[0] == '\n' || value[0] == '\t' || value == "";
    }
    
    public static bool IsInt(this char c)
    {
        return char.IsDigit(c);
    }
}