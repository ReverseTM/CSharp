namespace Sorting;

public sealed class InsertionSort : 
    ASort
{
    public override T[] Sort<T>(
        T[]? collection,
        SortingMode mode,
        Comparison<T> comparison)
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));
        
        for (var i = 1; i < collection.Length; i++)
        {
            var index = i;
            var currentNumber = collection[i];

            
            while (index > 0 
                   && (mode == SortingMode.Ascending
                       ? comparison(currentNumber, collection[index - 1]) < 0
                       : comparison(currentNumber, collection[index - 1]) > 0))
            {
                collection[index] = collection[index - 1]; 
                index -= 1;
            }
            
            collection[index] = currentNumber;
        }
        
        return collection;
    }
}