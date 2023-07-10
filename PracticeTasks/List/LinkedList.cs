using System.Collections;
using System.Text;
using Sorting;

namespace List;


public sealed class LinkedList<T> :
    IEnumerable<T>,
    IEquatable<LinkedList<T>>,
    ICloneable
{

    #region Node
    
    private sealed class LinkedListNode<T>
    {
        public LinkedListNode(T data)
        {
            Data = data;
            Next = null;
        }

        public T Data { get; set; }

        public LinkedListNode<T>? Next { get; set; }
    }

    #endregion Node

    #region ListFields

    private LinkedListNode<T>? _first;
    private LinkedListNode<T>? _last;
    private int _count;
    
    public int Count => _count;

    #endregion ListFields

    #region ListContructors

    public LinkedList()
    {
        _first = _last = null;
    }

    public LinkedList(IEnumerable<T> list)
    {
        foreach (var item in list)
        {
            PushBack(item);
        }
    }

    public LinkedList(LinkedList<T> list)
    {
        var currentNode = list._first;
        
        while (currentNode != null)
        {
            PushBack(currentNode.Data);
            currentNode = currentNode.Next;
        }
    }

    #endregion ListContructors

    #region CRD

    public LinkedList<T> PushFront(T? data)
    {
        if (data == null) throw new ArgumentNullException(nameof(data));

        _first = _first == null ? _last = new LinkedListNode<T>(data) : new LinkedListNode<T>(data) { Next = _first };

        _count++;

        return this;
    }

    public LinkedList<T> PushBack(T? data)
    {
        if (data == null) throw new ArgumentNullException(nameof(data));

        _last = _first == null ? _first = new LinkedListNode<T>(data) : _last!.Next = new LinkedListNode<T>(data);
        
        _count++;

        return this;
    }

    public LinkedList<T> InsertAt(T? data, int index)
    {
        if (data == null) throw new ArgumentNullException(nameof(data));

        if (index < 0 || index > _count) throw new ArgumentException("Index out of bounds" , nameof(index));

        var currentNode = _first;
        LinkedListNode<T>? previousNode = null;

        for (var i = 0; i < index; i++)
        {
            previousNode = currentNode;
            currentNode = currentNode!.Next;
        }

        currentNode = currentNode == null ? new LinkedListNode<T>(data) : new LinkedListNode<T>(data) {Next = currentNode};

        if (previousNode == null) _first = currentNode;
        else previousNode.Next = currentNode;

        if (index == _count) _last = currentNode;
        
        _count++;
        
        return this;
    }

    public LinkedList<T> PopFront()
    {
        if (_count == 0) throw new Exception("List is empty");

        _first = _count == 1 ? _last = null : _first!.Next;

        _count--;
        
        return this;
}
    
    public LinkedList<T> PopBack()
    {
        if (_count == 0) throw new Exception("List is empty");

        if (_count == 1) _first = _last = null;

        else
        {
            var currentNode = _first;
            LinkedListNode<T>? previousNode = null;

            while (!currentNode!.Next!.Equals(_last))
            {
                previousNode = currentNode;
                currentNode = currentNode.Next;
            }

            currentNode.Next = null;
            _last = currentNode;

            if (previousNode == null) _first = _last;
            else previousNode.Next = _last;    
        }

        _count--;
        
        return this;
    }
    
    public LinkedList<T> RemoveAt(int index)
    {
        if (index < 0 || index >= _count) throw new ArgumentException("Index out of bounds" , nameof(index));
        
        if (_count == 0) throw new Exception("List is empty");

        if (_count == 1) _first = _last = null;

        else
        {
            var currentNode = _first;
            LinkedListNode<T>? previousNode = null;

            for (var i = 0; i < index; i++)
            {
                previousNode = currentNode;
                currentNode = currentNode!.Next;
            }

            if (previousNode == null) _first = _first!.Next;
            else previousNode.Next = currentNode!.Next;
            
            if (index == _count - 1) _last = previousNode;
        }

        _count--;
        
        return this;
    }

    private LinkedList<T> FindAt(out T findValue, int index)
    {
        if (index < 0 || index >= _count) throw new ArgumentException("Index out of bounds" , nameof(index));
        
        if (_count == 0) throw new Exception("List is empty");

        var currentNode = _first;
        
        while (index > 0)
        {
            currentNode = currentNode!.Next;
            index--;
        }

        findValue = currentNode!.Data;

        return this;
    }

    private LinkedList<T> UpdateAt(T? data, int index)
    {
        if (data == null) throw new ArgumentNullException(nameof(data));
        
        if (index < 0 || index >= _count) throw new ArgumentException("Index out of bounds" , nameof(index));
        
        if (_count == 0) throw new Exception("List is empty");

        var currentNode = _first;
        
        while (index > 0)
        {
            currentNode = currentNode!.Next;
            index--;
        }

        currentNode!.Data = data;

        return this;
    }

    public T this[
        int index]
    {
        get
        {
            FindAt(out var findValue, index);
            return findValue;
        }

        set => UpdateAt(value, index);
    }

    #endregion CRD

    #region Functional
    
    public LinkedList<T> Reverse()
    {
        if (_count == 0) throw new Exception("List is empty");

        var newList = (LinkedList<T>)Clone();
        
        var currentNode = newList._first;
        LinkedListNode<T>? previousNode = null;

        while (currentNode != null)
        {
            var temp = currentNode.Next;
            currentNode.Next = previousNode;
            previousNode = currentNode;
            currentNode = temp;
        }
        
        (newList._first, newList._last) = (newList._last, newList._first);
        
        return newList;
    }

    public static LinkedList<T> Concat(
        LinkedList<T>? firstList,
        LinkedList<T>? secondList)
    {
        if (firstList == null) throw new ArgumentNullException(nameof(firstList));
        if (secondList == null) throw new ArgumentNullException(nameof(secondList));

        return new LinkedList<T>(firstList.Concat(secondList));
    }

    public static LinkedList<T> Intersection(
        LinkedList<T>? firstList,
        LinkedList<T>? secondList,
        IEqualityComparer<T> comparer)
    {
        if (firstList == null) throw new ArgumentNullException(nameof(firstList));
        if (secondList == null) throw new ArgumentNullException(nameof(secondList));

        return new LinkedList<T>(firstList.Intersect(secondList, comparer));
    }

    public static LinkedList<T> Union(
        LinkedList<T>? firstList,
        LinkedList<T>? secondList,
        IEqualityComparer<T> comparer)
    {
        if (firstList == null) throw new ArgumentNullException(nameof(firstList));
        if (secondList == null) throw new ArgumentNullException(nameof(secondList));

        return new LinkedList<T>(firstList.Union(secondList, comparer));
    }

    public static LinkedList<T> Except(
        LinkedList<T>? firstList,
        LinkedList<T>? secondList,
        IEqualityComparer<T> comparer)
    {
        if (firstList == null) throw new ArgumentNullException(nameof(firstList));
        if (secondList == null) throw new ArgumentNullException(nameof(secondList));

        return new LinkedList<T>(firstList.Except(secondList, comparer));
    }

    public static LinkedList<T> OperatorStar(
        LinkedList<T>? firstList,
        LinkedList<T>? secondList)
    {
        if (firstList == null) throw new ArgumentNullException(nameof(firstList));
        if (secondList == null) throw new ArgumentNullException(nameof(secondList));
        
        var size = firstList._count < secondList._count ? firstList._count : secondList._count;

        var newList = new LinkedList<T>();

        for (var i = 0; i < size; i++)
        {
            newList.PushBack((dynamic?)firstList[i] * secondList[i]);
        }

        return newList;
    }
    
    public void Each(Action<T> action)
    {
        if (action == null) throw new ArgumentNullException(nameof(action));
        if (_count == 0) throw new Exception("List is empty");

        foreach (var item in this)
        {
            action(item);
        }
    }
    
    #endregion Functional

    #region Operators
    
    public static LinkedList<T> operator !(LinkedList<T>? list)
    {
        return list?.Reverse() ?? throw new ArgumentNullException(nameof(list));
    }

    public static LinkedList<T> operator +(
        LinkedList<T>? firstList,
        LinkedList<T>? secondList)
    {
        return Concat(firstList, secondList);
    }

    public static LinkedList<T> operator &(
        LinkedList<T>? firstList,
        LinkedList<T>? secondList)
    {
        return Intersection(firstList, secondList, EqualityComparer<T>.Default);
    }

    public static LinkedList<T> operator |(
        LinkedList<T>? firstList,
        LinkedList<T>? secondList)
    {
        return Union(firstList, secondList, EqualityComparer<T>.Default);
    }
    
    public static LinkedList<T> operator -(
        LinkedList<T>? firstList,
        LinkedList<T>? secondList)
    {
        return Except(firstList, secondList, EqualityComparer<T>.Default);
    }

    public static LinkedList<T> operator *(
        LinkedList<T>? firstList,
        LinkedList<T>? secondList)
    {
        return OperatorStar(firstList, secondList);
    }

    public static bool operator ==(
        LinkedList<T>? firstList,
        LinkedList<T>? secondList)
    {
        if (firstList is null && secondList is null) return true;
        if (firstList is null || secondList is null) return false;

        return firstList.Equals(secondList);
    }
    
    public static bool operator !=(
        LinkedList<T>? firstList,
        LinkedList<T>? secondList)
    {
        if (firstList is null && secondList is null) return false;
        if (firstList is null || secondList is null) return true;
        
        return !(firstList.Equals(secondList));
    }

    #endregion Operators

    #region Sorting

    public LinkedList<T> Sort(
        IComparer<T>? comparer,
        ASort.SortingMode mode = ASort.SortingMode.Ascending,
        ASort.SortingAlgorithm algorithm = ASort.SortingAlgorithm.QuickSort)
    {
        if (comparer == null) throw new ArgumentNullException(nameof(comparer));
        if (_count == 0) throw new Exception("List is empty");

        return new LinkedList<T>(this.ToArray().Sort(mode, algorithm, comparer));
    }
    
    public LinkedList<T> Sort(
        Comparer<T>? comparer,
        ASort.SortingMode mode = ASort.SortingMode.Ascending,
        ASort.SortingAlgorithm algorithm = ASort.SortingAlgorithm.QuickSort)
    {
        if (comparer == null) throw new ArgumentNullException(nameof(comparer));
        if (_count == 0) throw new Exception("List is empty");

        return new LinkedList<T>(this.ToArray().Sort(mode, algorithm, comparer));
    }
    
    public LinkedList<T> Sort(
        Comparison<T>? comparer,
        ASort.SortingMode mode = ASort.SortingMode.Ascending,
        ASort.SortingAlgorithm algorithm = ASort.SortingAlgorithm.QuickSort)
    {
        if (comparer == null) throw new ArgumentNullException(nameof(comparer));
        if (_count == 0) throw new Exception("List is empty");

        return new LinkedList<T>(this.ToArray().Sort(mode, algorithm, comparer));
    }

    #endregion Sorting
    
    public object Clone()
    {
        return new LinkedList<T>(this);
    }

    public bool Equals(LinkedList<T>? other)
    {
        if (other == null) return false;

        if (_count != other._count) return false;

        if (_count == 0) return true;
        
        var thisNode = _first;
        var otherNode = other._first;

        while (thisNode != null)
        {
            if (thisNode.Data == null && otherNode!.Data != null) return false;
            if (!thisNode.Data!.Equals(otherNode!.Data)) return false;
            
            thisNode = thisNode.Next;
            otherNode = otherNode.Next;
        }

        return true;
    }

    public override bool Equals(
        object? obj)
    {
        if (obj == null) return false;

        if (obj is LinkedList<T> list) return Equals(list);

        return false;
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        var currentNode = _first;

        while (currentNode != null)
        {
            hashCode.Add(currentNode.Data);
            currentNode = currentNode.Next;
        }

        return hashCode.ToHashCode();
    }

    public override string ToString()
    {
        var listString = new StringBuilder();

        foreach (var item in this)
        {
            listString.Append($"[{item}] ");
        }
        
        return $"Count = {Count}, List: {listString}";
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currentNode = _first;
        while (currentNode != null)
        {
            yield return currentNode.Data;
            currentNode = currentNode.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}