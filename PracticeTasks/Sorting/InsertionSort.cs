namespace Sorting;

public sealed class InsertionSort<T> : 
    ASort<T>
{
    public override T[] Sort(T[]? collection, SortingMode mode)
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));
        
        for (var i = 1; i < collection.Length; i++)
        {
            var index = i;
            var currentNumber = collection[i];

            
            while (index > 0 
                   && (mode == SortingMode.Ascending
                       ? (dynamic?)currentNumber < collection[index - 1]
                       : (dynamic?)currentNumber > collection[index - 1]))
            {
                collection[index] = collection[index - 1]; 
                index -= 1;
            }
            
            collection[index] = currentNumber;
        }
        
        return collection;
    }
}