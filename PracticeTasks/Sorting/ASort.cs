namespace Sorting;

public abstract class ASort
{
    public enum SortingMode
    {
        Ascending,
        Descending
    }

    public enum SortingAlgorithm
    {
        InsertionSort,
        SelectionSort,
        QuickSort,
        HeapSort,
        MergeSort
    }
    
    public abstract T[] Sort<T>(T[]? collection, SortingMode mode, Comparison<T> comparison);
}