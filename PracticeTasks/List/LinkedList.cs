namespace List;

public sealed class LinkedList<T>
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

    #endregion ListFields

    #region ListContructors

    public LinkedList()
    {
        _first = _last = null;
    }

    #endregion ListContructors

    public int Count => _count;
    public T First => _first.Data;
    public T Last => _last.Data;

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
        if (_count == 0) throw new IndexOutOfRangeException("List is empty");

        _first = _count == 1 ? _last = null : _first!.Next;

        _count--;
        
        return this;
}
    
    public LinkedList<T> PopBack()
    {
        if (_count == 0) throw new IndexOutOfRangeException("List is empty");

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
        
        if (_count == 0) throw new IndexOutOfRangeException("List is empty");

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
        
        if (_count == 0) throw new IndexOutOfRangeException("List is empty");

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
        
        if (_count == 0) throw new IndexOutOfRangeException("List is empty");

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

    #region plushki

    public LinkedList<T> Reverse()
    {
        if (_count == 0) throw new IndexOutOfRangeException("List is empty");

        var currentNode = _first;
        LinkedListNode<T>? previousNode = null;

        while (currentNode != null)
        {
            var temp = currentNode.Next;
            currentNode.Next = previousNode;
            previousNode = currentNode;
            currentNode = temp;
        }
        
        //TODO ПЕРЕДЕЛАТЬ ПОЗЖЕ
        
        return this;
    }

    #endregion plushki
}