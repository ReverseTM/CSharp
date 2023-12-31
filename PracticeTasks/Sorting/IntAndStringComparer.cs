namespace Sorting;

public sealed class IntAndStringComparer :
    IComparer<IntAndString>
{
    private static IntAndStringComparer? _instance;
    private IntAndStringComparer() {}

    public static IntAndStringComparer Instance
    {
        get
        {
            return _instance ??= new IntAndStringComparer();
        }
    }

    int IComparer<IntAndString>.Compare(IntAndString? x, IntAndString? y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (ReferenceEquals(null, y)) return 1;
        if (ReferenceEquals(null, x)) return -1;
        
        return string.Compare(x.StringValue, y.StringValue, StringComparison.Ordinal);
    }
    
    public static int Compare(IntAndString? x, IntAndString? y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (ReferenceEquals(null, y)) return 1;
        if (ReferenceEquals(null, x)) return -1;
        
        return string.Compare(x.StringValue, y.StringValue, StringComparison.Ordinal);
    }
}