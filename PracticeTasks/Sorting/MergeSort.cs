namespace Sorting;

public sealed class MergeSort<T> : 
    ASort<T>
{
    public override T[] Sort(
        T[]? collection,
        SortingMode mode)
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));
        
        return MSort(collection, 0, collection.Length - 1, mode);
    }
    
    private static T[] MSort(T[] collection, int lowIndex, int highIndex, SortingMode mode)
    {
        if (lowIndex < highIndex)
        {
            var middleIndex = (lowIndex + highIndex) / 2;
            MSort(collection, lowIndex, middleIndex, mode);
            MSort(collection, middleIndex + 1, highIndex, mode);
            Merge(collection, lowIndex, middleIndex, highIndex, mode);
        }

        return collection;
    }
    
    private static void Merge(T[] collection, int lowIndex, int middleIndex, int highIndex, SortingMode mode)
    {
        var left = lowIndex;
        var right = middleIndex + 1;
        var tempArray = new int[highIndex - lowIndex + 1];
        var index = 0;

        while ((left <= middleIndex) && (right <= highIndex))
        {
            if (mode == SortingMode.Ascending ? (dynamic?)collection[left] < collection[right] : (dynamic?)collection[left] > collection[right])
            {
                tempArray[index] = (dynamic?)collection[left];
                left++;
            }
            else
            {
                tempArray[index] = (dynamic?)collection[right];
                right++;
            }

            index++;
        }

        for (var i = left; i <= middleIndex; i++)
        {
            tempArray[index] = (dynamic?)collection[i];
            index++;
        }

        for (var i = right; i <= highIndex; i++)
        {
            tempArray[index] = (dynamic?)collection[i];
            index++;
        }

        for (var i = 0; i < tempArray.Length; i++)
        {
            collection[lowIndex + i] = (dynamic)tempArray[i];
        }
    }
}