namespace EnumTesting;

public class Something : Enumeration<string, Something>
{
    public const string AlphaKey = "Alpha";
    public const string BetaKey = "Beta";
    public const string CharlieKey = "Charlie";

    public static readonly Something Alpha = new(AlphaKey, "AlphaValue");
    public static readonly Something Beta = new(BetaKey, "BetaValue");
    public static readonly Something Charlie = new(CharlieKey, "CharlieValue");

    public Something(string key, string value) : base(key, value)
    {
    }
}
