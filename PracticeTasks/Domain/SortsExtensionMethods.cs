using System.Runtime.Intrinsics.X86;
using Sorting;
namespace Domain;
public static class SortsExtensionMethods
{
    public static T[] Sort<T>(
        this T[] collection,
        ASort<T>.SortingMode mode,
        ASort<T> sortAlgorithm) where T : IComparable<T>
    {
        int Comparison(T x, T y) => x.CompareTo(y);

        return sortAlgorithm.Sort(collection, mode, Comparison);
    }

    public static T[] Sort<T>(this T[] collection,
        ASort<T>.SortingMode mode,
        ASort<T> sortAlgorithm,
        IComparer<T> comparer)
    {
        return sortAlgorithm.Sort(collection, mode, comparer.Compare);
    }

    public static T[] Sort<T>(
        this T[] collection,
        ASort<T>.SortingMode mode,
        ASort<T> sortAlgorithm,
        Comparer<T> comparer)
    {
        return sortAlgorithm.Sort(collection, mode, comparer.Compare);
    }

    public static T[] Sort<T>(
        this T[] collection,
        ASort<T>.SortingMode mode,
        ASort<T> sortAlgorithm,
        Comparison<T> comparison)
    {
        return sortAlgorithm.Sort(collection, mode, comparison);
    }
}