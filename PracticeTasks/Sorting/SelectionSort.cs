namespace Sorting;

public sealed class SelectionSort : 
    ASort
{
    public override T[] Sort<T>(
        T[]? collection,
        SortingMode mode,
        Comparison<T> comparison)
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));

        var lenght = collection.Length;

        for (var i = 0; i < lenght; i++)
        {
            var currentIndex = i;
            
            for (var j = i + 1; j < lenght; j++)
            {
                if (mode == SortingMode.Ascending
                        ? comparison(collection[j], collection[currentIndex]) < 0
                        : comparison(collection[j], collection[currentIndex]) > 0)
                {
                    currentIndex = j;
                }
            }
            (collection[currentIndex], collection[i]) = (collection[i], collection[currentIndex]);
        }

        return collection;
    }
}