namespace Domain;

public class ElementsEqualityComparer<T>:
    IEqualityComparer<T>
{
    private static ElementsEqualityComparer<T>? _instance;
    
    private ElementsEqualityComparer() {}

    public static ElementsEqualityComparer<T> Instance => _instance ??= new ElementsEqualityComparer<T>();
    
    public bool Equals(T? x, T? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (ReferenceEquals(x, null)) return false;
        if (ReferenceEquals(y, null)) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Equals(y);
    }

    public int GetHashCode(T? obj)
    {
        return obj.GetHashCode();
    }
}