using Domain;

namespace Domain;

public sealed class IntAndString :
    IComparable,
    IComparable<IntAndString>
{
    public IntAndString(int @int, string @string)
    {
        IntValue = @int;
        StringValue = @string ?? throw new ArgumentNullException(nameof(@string));
    }

    public int IntValue
    {
        get;

        private set;
    }

    public string StringValue
    {
        get;

        private set;
    }

    public int CompareTo(object? other)
    {
        if (other == null) throw new ArgumentNullException(nameof(other));
    
        if (other is IntAndString obj)
        {
            return CompareTo(obj);
        }
        
        throw new ArgumentException("Can't perform comparison operation", nameof(other));
    }
    
    public int CompareTo(IntAndString? other)
    {
        if (other == null) throw new ArgumentNullException(nameof(other));
    
        return IntValue.CompareTo(other.IntValue);
    }

    public override string ToString()
    {
        return $"[ IntValue: {IntValue}, StringValue {StringValue} ]";
    }
}