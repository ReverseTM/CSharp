namespace PracticeDomain;

public class TestClassEqualityComparer:
    IEqualityComparer<TestClass>
{
    private static TestClassEqualityComparer? _instance;
    
    private TestClassEqualityComparer() {}

    public static TestClassEqualityComparer Instance => _instance ??= new TestClassEqualityComparer();
    
    public bool Equals(TestClass? x, TestClass? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (ReferenceEquals(x, null)) return false;
        if (ReferenceEquals(y, null)) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.StringValue.Equals(y.StringValue, StringComparison.Ordinal);
    }

    public int GetHashCode(TestClass obj)
    {
        return obj.StringValue.GetHashCode();
    }
}