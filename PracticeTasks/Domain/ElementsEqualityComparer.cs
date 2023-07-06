namespace Domain;

public class ElementsEqualityComparer:
    IEqualityComparer<int>
{
    private static ElementsEqualityComparer? _instance;
    
    private ElementsEqualityComparer() {}

    public static ElementsEqualityComparer Instance => _instance ??= new ElementsEqualityComparer();
    
    public bool Equals(int x, int y)
    {
        return x == y;
    }

    public int GetHashCode(int obj)
    {
        return obj.GetHashCode();
    }
}