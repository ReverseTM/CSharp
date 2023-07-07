namespace Sorting;

public sealed class SelectionSort<T> : 
    ASort<T>
{
    public override T[] Sort(
        T[]? collection,
        SortingMode mode)
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));

        var lenght = collection.Length;

        for (var i = 0; i < lenght; i++)
        {
            var currentIndex = i;
            
            for (var j = i + 1; j < lenght; j++)
            {
                if (mode == SortingMode.Ascending
                        ? collection[j] < (dynamic?)collection[currentIndex]
                        : collection[j] > (dynamic?)collection[currentIndex])
                {
                    currentIndex = j;
                }
            }
            (collection[currentIndex], collection[i]) = (collection[i], collection[currentIndex]);
        }

        return collection;
    }
}