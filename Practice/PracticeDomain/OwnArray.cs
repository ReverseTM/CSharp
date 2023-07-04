using System.Collections;

namespace PracticeDomain;

public class OwnArray:
    IEnumerable<int>
{
    private int[] _array;
    private int _actualSize;

    public OwnArray()
    {
        _array = new int[16];
        _actualSize = 0;
    }

    public void Insert(
        int value,
        int index)
    {
        
    }

    public int FindByIndex(
        int index)
    {
        throw new NotImplementedException();
    }

    public int RemoveByIndex(
        int index)
    {
        throw new NotImplementedException();
    }
    
    //Списковый генератор, генератор последовательностей
    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < _array.Length; i++)
        {
            yield return _array[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}