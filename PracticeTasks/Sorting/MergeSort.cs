namespace Sorting;

public sealed class MergeSort<T> : 
    ASort<T>
{
    public override T[] Sort(
        T[]? collection,
        SortingMode mode,
        Comparison<T> comparison)
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));
        
        return MSort(collection, 0, collection.Length - 1, mode, comparison);
    }
    
    private static T[] MSort(
        T[] collection,
        int lowIndex,
        int highIndex,
        SortingMode mode,
        Comparison<T> comparison)
    {
        if (lowIndex < highIndex)
        {
            var middleIndex = (lowIndex + highIndex) / 2;
            MSort(collection, lowIndex, middleIndex, mode, comparison);
            MSort(collection, middleIndex + 1, highIndex, mode, comparison);
            Merge(collection, lowIndex, middleIndex, highIndex, mode, comparison);
        }

        return collection;
    }
    
    private static void Merge(
        T[] collection,
        int lowIndex,
        int middleIndex,
        int highIndex,
        SortingMode mode,
        Comparison<T> comparison)
    {
        var left = lowIndex;
        var right = middleIndex + 1;
        var tempArray = new T[highIndex - lowIndex + 1];
        var index = 0;

        while ((left <= middleIndex) && (right <= highIndex))
        {
            if (mode == SortingMode.Ascending 
                    ? comparison(collection[left], collection[right]) < 0 
                    : comparison(collection[left], collection[right]) > 0)
            {
                tempArray[index] = collection[left];
                left++;
            }
            else
            {
                tempArray[index] = collection[right];
                right++;
            }

            index++;
        }

        for (var i = left; i <= middleIndex; i++)
        {
            tempArray[index] = collection[i];
            index++;
        }

        for (var i = right; i <= highIndex; i++)
        {
            tempArray[index] = collection[i];
            index++;
        }

        for (var i = 0; i < tempArray.Length; i++)
        {
            collection[lowIndex + i] = tempArray[i];
        }
    }
}