namespace Sorting;

public sealed class QuickSort<T> : 
    ASort<T>
{
    public override T[] Sort(
        T[]? collection,
        SortingMode mode,
        Comparison<T> comparison)
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));

        return QSort(collection, 0, collection.Length - 1, mode, comparison);
    }
    
    private static T[] QSort(
        T[] collection,
        int minIndex,
        int maxIndex,
        SortingMode mode,
        Comparison<T> comparison)
    {
        if (minIndex >= maxIndex) return collection;
        

        var pivotIndex = FindPivot(collection, minIndex, maxIndex, mode, comparison);
        QSort(collection, minIndex, pivotIndex - 1, mode, comparison);
        QSort(collection, pivotIndex + 1, maxIndex, mode, comparison);

        return collection;
    }
    
    private static int FindPivot(
        T[] collection,
        int minIndex,
        int maxIndex,
        SortingMode mode,
        Comparison<T> comparison)
    {
        var pivot = minIndex - 1;
        
        for (var i = minIndex; i < maxIndex; i++)
        {
            if (mode == SortingMode.Ascending 
                    ? comparison(collection[i], collection[maxIndex]) < 0
                    : comparison(collection[i], collection[maxIndex]) > 0)
            {
                pivot++;
                (collection[pivot], collection[i]) = (collection[i], collection[pivot]);
            }
        }

        pivot++;
        (collection[pivot], collection[maxIndex]) = (collection[maxIndex], collection[pivot]);
        
        return pivot;
    }
}