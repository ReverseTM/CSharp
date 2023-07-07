using Sorting;
namespace Domain;
public static class SortsExtensionMethods
{
    public static T[] Sort<T>(
        this T[] collection,
        ASort<T>.SortingMode mode,
        ASort<T> sortAlgorithm) where T : IComparable<T>
    {
        return sortAlgorithm.Sort(collection, mode);
    }

    public static T[] Sort<T>(this T[] collection,
        ASort<T>.SortingMode mode,
        ASort<T> sortAlgorithm,
        IComparer<T> comparer)
    {
        return sortAlgorithm.Sort(collection, mode);
    }

    public static T[] Sort<T>(
        this T[] collection,
        ASort<T>.SortingMode mode,
        ASort<T> sortAlgorithm,
        Comparer<T> comparer)
    {
        return sortAlgorithm.Sort(collection, mode);
    }

    public static T[] Sort<T>(
        this T[] collection,
        ASort<T>.SortingMode mode,
        ASort<T> sortAlgorithm,
        Comparison<T> comparison)
    {
        return sortAlgorithm.Sort(collection, mode);
    }
}