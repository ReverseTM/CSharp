namespace Sorting;

public sealed class HeapSort<T> : 
    ASort<T>
{
    public override T[] Sort(
        T[]? collection,
        SortingMode mode,
        Comparison<T> comparison)
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));
        
        var size = collection.Length;
        
        for (var i = size / 2 - 1; i >= 0; i--) Heapify(collection, size, i, mode, comparison);
        
        for (var i = size - 1; i >= 0; i--)
        {
            (collection[0], collection[i]) = (collection[i], collection[0]);
            Heapify(collection, i, 0, mode, comparison);
        }

        return collection;
    }
    
    private static void Heapify(
        T[] collection,
        int size,
        int root,
        SortingMode mode,
        Comparison<T> comparison)
    {
        var maxOrMin = root;
        
        var left = 2 * root + 1;
        var right = 2 * root + 2;

        if (left < size && (mode == SortingMode.Ascending
                ? comparison(collection[left], collection[maxOrMin]) > 0
                : comparison(collection[left], collection[maxOrMin]) < 0))
        {
            maxOrMin = left;
        }

        if (right < size && (mode == SortingMode.Ascending
                ? comparison(collection[right], collection[maxOrMin]) > 0
                : comparison(collection[right], collection[maxOrMin]) < 0))
        {
            maxOrMin = right;
        }

        if (maxOrMin != root)
        {
            (collection[root], collection[maxOrMin]) = (collection[maxOrMin], collection[root]);
            
            Heapify(collection, size, maxOrMin, mode, comparison);
        }
    }
}