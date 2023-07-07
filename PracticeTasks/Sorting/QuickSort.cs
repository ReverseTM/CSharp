namespace Sorting;

public class QuickSort<T>
{
    private static int FindPivot(
        T[] collection,
        int minIndex,
        int maxIndex,
        ISort.SortingMode mode)
    {
        var pivot = minIndex - 1;
        
        for (var i = minIndex; i < maxIndex; i++)
        {
            if (mode == ISort.SortingMode.Ascending 
                    ? (dynamic?)collection[i] < collection[maxIndex]
                    : (dynamic?)collection[i] > collection[maxIndex])
            {
                pivot++;
                (collection[pivot], collection[i]) = (collection[i], collection[pivot]);
            }
        }

        pivot++;
        (collection[pivot], collection[maxIndex]) = (collection[maxIndex], collection[pivot]);
        
        return pivot;
    }

    private static T[] QSort(
        T[] collection,
        int minIndex,
        int maxIndex,
        ISort.SortingMode mode)
    {
        if (minIndex >= maxIndex) return collection;
        

        var pivotIndex = FindPivot(collection, minIndex, maxIndex, mode);
        QSort(collection, minIndex, pivotIndex - 1, mode);
        QSort(collection, pivotIndex + 1, maxIndex, mode);

        return collection;
    }
    
    public static T[] Sort(
        T[]? collection,
        ISort.SortingMode mode)
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));

        return QSort(collection, 0, collection.Length - 1, mode);
    }
}