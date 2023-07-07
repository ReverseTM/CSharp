namespace Sorting;

public interface ISort
{
    public enum SortingMode
    {
        Ascending,
        Descending
    }

    public object[] Sort(object[]? collection, SortingMode mode);
}