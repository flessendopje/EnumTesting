using System.Reflection;

namespace EnumTesting;
public abstract class Enumeration<TValue, TCallerType> : IComparable where TCallerType : Enumeration<TValue, TCallerType> where TValue : IComparable
{
    protected Enumeration(string key, TValue value)
    {
        Key = key;
        Value = value;
    }
    public string Key { get; init; }
    public TValue Value { get; init; }
    public override string ToString() => Key;

    public static IEnumerable<TCallerType> GetAll()
    {
        var found = typeof(TCallerType).GetFields(BindingFlags.Public | BindingFlags.Static)
            .Where(field => field.FieldType == typeof(TCallerType))
            .Select(field => (TCallerType)field.GetValue(null)!);

        return found;
    }

    public static TCallerType FromKey(string value) =>
        Parse(value, "key", item => item.Key == value);

    public static TCallerType FromValue(TValue value) =>
        Parse(value, "value", item => item.Value.Equals(value));

    private static TCallerType Parse<T>(T value, string description, Func<TCallerType, bool> predicate)
    {
        TCallerType? matchingItem = GetAll().FirstOrDefault(predicate);
        if (matchingItem != null)
            return matchingItem;

        throw new ApplicationException($"'{value}' is not a valid {description} in {typeof(TCallerType)}");
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Enumeration<TValue, TCallerType> otherValue)
            return false;

        bool typeMatches = GetType().Equals(obj?.GetType());
        bool valueMatches = Value.Equals(otherValue.Value);
        return typeMatches && valueMatches;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public int CompareTo(object? other) => Value!.CompareTo(((Enumeration<TValue, TCallerType>)other!).Value);

    public static implicit operator TValue(Enumeration<TValue, TCallerType> enumeration) => enumeration.Value;
}
