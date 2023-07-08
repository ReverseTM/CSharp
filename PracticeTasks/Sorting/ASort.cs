namespace Sorting;

public abstract class ASort<T>
{
    public enum SortingMode
    {
        Ascending,
        Descending
    }

    public abstract T[] Sort(T[]? collection, SortingMode mode, Comparison<T> comparison);
}