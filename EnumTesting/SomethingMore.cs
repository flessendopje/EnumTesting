namespace EnumTesting;

public class SomethingMore : Enumeration<string, SomethingMore>
{
    public const string DeltaKey = "Delta";
    public const string EchoKey = "Echo";
    public const string FoxtrotKey = "Foxtrot";

    public static readonly SomethingMore Delta = new(DeltaKey, "DeltaValue");
    public static readonly SomethingMore Echo = new(EchoKey, "EchoValue");
    public static readonly SomethingMore Foxtrot = new(FoxtrotKey, "FoxtrotValue");

    public SomethingMore(string key, string value) : base(key, value)
    {
    }
}
