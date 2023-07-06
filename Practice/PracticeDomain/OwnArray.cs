using System.Collections;

namespace PracticeDomain;

public class OwnArray<T>:
    IEnumerable<T>
    //where T: List<T>, IComparable, IComparable<T>, new()
{
    public enum SortingMode
    {
        Ascending,
        Descending
    }
    
    private List<T> _array;

    public OwnArray()
    {
        _array = new List<T>();
    }

    public OwnArray<T> Insert(
        T value,
        int index)
    {
        _array.Insert(index, value);
        return this;
    }

    public OwnArray<T> FindByIndex(
        int index,
        out T foundValue)
    {
        foundValue = _array[index];
        return this;
    }

    public OwnArray<T> RemoveByIndex(
        int index,
        out T removedValue)
    {
        FindByIndex(index, out removedValue);
        _array.RemoveAt(index);
        return this;
    }
    
    public OwnArray<T> Sort(
        IComparer<T> comparer)
    {
        _array.Sort(comparer);
        return this;
    }
    
    public OwnArray<T> Sort()
    {
        _array.Sort();
        return this;
    }

    public void FooEach(
        Action<T> action)
    {
        foreach (var item in _array)
        {
            action(item);
        }
    }
    
    //Списковый генератор, генератор последовательностей
    public IEnumerator<T> GetEnumerator()
    {
        foreach (var arrayItem in _array)
        {
            yield return arrayItem;
        }
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _array)}]";
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    
}