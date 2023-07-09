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

    public LinkedList<T> InsertByIndex(T? data, int index)
    {
        if (data == null) throw new ArgumentNullException(nameof(data));

        if (index > _count) throw new ArgumentException("Index out of bounds" , nameof(index));

        var currentNode = _first;
        LinkedListNode<T>? previousNode = null;

        for (var i = 0; i < index && currentNode != null; i++)
        {
            previousNode = currentNode;
            currentNode = currentNode.Next;
        }

        currentNode = currentNode == null ? new LinkedListNode<T>(data) : new LinkedListNode<T>(data) {Next = currentNode};

        if (previousNode == null) _first = _last = currentNode;
        else previousNode.Next = currentNode;
        
        _count++;
        
        return this;
    }

    public LinkedList<T> PopFront(T? data)
    {
        throw new NotImplementedException();
    }
    
    public LinkedList<T> PopBack(T? data)
    {
        throw new NotImplementedException();
    }
    
    public LinkedList<T> RemoveByIndex(T? data, int index)
    {
        throw new NotImplementedException();
    }

    #endregion CRD
}