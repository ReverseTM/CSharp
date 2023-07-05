namespace PracticeDomain;

public sealed class TestClassComparer :
    IComparer<TestClass>
{
    private static TestClassComparer? _instance;
    private TestClassComparer() {}

    public static TestClassComparer Instance
    {
        get
        {
            return _instance ??= new TestClassComparer();
        }
    }
    
    public int Compare(TestClass? x, TestClass? y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (ReferenceEquals(null, y)) return 1;
        if (ReferenceEquals(null, x)) return -1;

        if ((x.IntValue & 1) == 0 && (y.IntValue & 1) == 1)
        {
            return 1;
        }

        if ((x.IntValue & 1) == 1 && (y.IntValue & 1) == 0)
        {
            return -1;
        }
        
        return x.IntValue.CompareTo(y.IntValue);
    }
}