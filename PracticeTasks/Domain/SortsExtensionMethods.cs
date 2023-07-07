using Sorting;
namespace Domain;
public static class SortsExtensionMethods
{

    public static T[] Sort<T>(
        this T[] collection,
        ISort.SortingMode mode,
        Delegate sortAlgorithm) where T : IComparable<T>
    {
        throw new NotImplementedException();
    }

    public static T[] Sort<T>(this T[] collection,
        ISort.SortingMode mode,
        Delegate sortAlgorithm,
        IComparer<T> comparer)
    {
        throw new NotImplementedException();
    }

    public static T[] Sort<T>(
        this T[] collection,
        ISort.SortingMode mode,
        Delegate sortAlgorithm,
        Comparer<T> comparer)
    {
        throw new NotImplementedException();
    }

    public static T[] Sort<T>(
        this T[] collection,
        ISort.SortingMode mode,
        Delegate sortAlgorithm,
        Comparison<T> comparison)
    {
        throw new NotImplementedException();
    }
}