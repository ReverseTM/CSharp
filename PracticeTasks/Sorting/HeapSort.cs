namespace Sorting;

public sealed class HeapSort<T> : 
    ASort<T>
{
    public override T[] Sort(
        T[]? collection,
        SortingMode mode)
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));
        
        var n = collection.Length;
        
        for (var i = n / 2 - 1; i >= 0; i--) Heapify(collection, n, i, mode);
        
        for (var i = n - 1; i >= 0; i--)
        {
            (collection[0], collection[i]) = (collection[i], collection[0]);
            Heapify(collection, i, 0, mode);
        }

        return collection;
    }
    
    private static void Heapify(T[] collection, int n, int i, SortingMode mode)
    {
        var maxOrMin = i;
        
        var left = 2 * i + 1;
        var right = 2 * i + 2;

        if (left < n && (mode == SortingMode.Ascending
                ? (dynamic?)collection[left] > collection[maxOrMin]
                : (dynamic?)collection[left] < collection[maxOrMin]))
        {
            maxOrMin = left;
        }

        if (right < n && (mode == SortingMode.Ascending
                ? (dynamic?)collection[right] > collection[maxOrMin]
                : (dynamic?)collection[right] < collection[maxOrMin]))
        {
            maxOrMin = right;
        }

        if (maxOrMin != i)
        {
            (collection[i], collection[maxOrMin]) = (collection[maxOrMin], collection[i]);
            
            Heapify(collection, n, maxOrMin, mode);
        }
    }
}