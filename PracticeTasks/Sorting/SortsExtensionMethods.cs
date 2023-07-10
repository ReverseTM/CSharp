namespace Sorting;
public static class SortsExtensionMethods
{
    public static T[] Sort<T>(
        this T[]? collection,
        ASort.SortingMode mode,
        ASort.SortingAlgorithm algorithm) where T : IComparable<T>
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));
        
        ASort? sortAlgorithm = algorithm switch
        {
            ASort.SortingAlgorithm.InsertionSort => new InsertionSort(),
            ASort.SortingAlgorithm.SelectionSort => new SelectionSort(),
            ASort.SortingAlgorithm.QuickSort => new QuickSort(),
            ASort.SortingAlgorithm.HeapSort => new HeapSort(),
            ASort.SortingAlgorithm.MergeSort => new MergeSort(),
            _ => throw new ArgumentException("Chosen invalid sorting algorithm", nameof(algorithm))
        };
        return sortAlgorithm!.Sort(collection, mode, (x, y) => x.CompareTo(y));
    }

    public static T[] Sort<T>(this T[] collection,
        ASort.SortingMode mode,
        ASort.SortingAlgorithm algorithm,
        IComparer<T> comparer)
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));
        
        ASort? sortAlgorithm = algorithm switch
        {
            ASort.SortingAlgorithm.InsertionSort => new InsertionSort(),
            ASort.SortingAlgorithm.SelectionSort => new SelectionSort(),
            ASort.SortingAlgorithm.QuickSort => new QuickSort(),
            ASort.SortingAlgorithm.HeapSort => new HeapSort(),
            ASort.SortingAlgorithm.MergeSort => new MergeSort(),
            _ => throw new ArgumentException("Chosen invalid sorting algorithm", nameof(algorithm))
        };
        return sortAlgorithm!.Sort(collection, mode, comparer.Compare);
    }

    public static T[] Sort<T>(
        this T[] collection,
        ASort.SortingMode mode,
        ASort.SortingAlgorithm algorithm,
        Comparer<T> comparer)
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));
        
        ASort? sortAlgorithm = algorithm switch
        {
            ASort.SortingAlgorithm.InsertionSort => new InsertionSort(),
            ASort.SortingAlgorithm.SelectionSort => new SelectionSort(),
            ASort.SortingAlgorithm.QuickSort => new QuickSort(),
            ASort.SortingAlgorithm.HeapSort => new HeapSort(),
            ASort.SortingAlgorithm.MergeSort => new MergeSort(),
            _ => throw new ArgumentException("Chosen invalid sorting algorithm", nameof(algorithm))
        };
        return sortAlgorithm!.Sort(collection, mode, comparer.Compare);
    }

    public static T[] Sort<T>(
        this T[] collection,
        ASort.SortingMode mode,
        ASort.SortingAlgorithm algorithm,
        Comparison<T> comparison)
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));
        
        ASort? sortAlgorithm = algorithm switch
        {
            ASort.SortingAlgorithm.InsertionSort => new InsertionSort(),
            ASort.SortingAlgorithm.SelectionSort => new SelectionSort(),
            ASort.SortingAlgorithm.QuickSort => new QuickSort(),
            ASort.SortingAlgorithm.HeapSort => new HeapSort(),
            ASort.SortingAlgorithm.MergeSort => new MergeSort(),
            _ => throw new ArgumentException("Chosen invalid sorting algorithm", nameof(algorithm))
        };
        return sortAlgorithm!.Sort(collection, mode, comparison);
    }
}