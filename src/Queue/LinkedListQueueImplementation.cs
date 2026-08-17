using System.Collections;

// implementation
var cola = new LinkedListQueue<string>();
cola.Enqueue("A");
cola.Enqueue("B");
cola.Enqueue("C");
cola.Dequeue();
Console.WriteLine(cola.Peek());

foreach (var item in cola)
    Console.WriteLine(item);

public class LinkedListQueue<T> : IEnumerable<T>
{
    private readonly SinglyLinkedList<T> _list = new SinglyLinkedList<T>();
    public void Enqueue(T item)
    {
        _list.AddList(item);
    }
    public void Dequeue()
    {
        _list.RemoveFirst();
    }
    public T Peek()
    {
        if (IsEmpty)
            throw new InvalidOperationException();

        return _list.Head!.Value;
    }
    public int Count => _list.Count;
    public bool IsEmpty => _list.Count == 0;

    public IEnumerator<T> GetEnumerator()
    {
        return _list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class SinglyLinkedList<T> : IEnumerable<T>
{
    public class Node
    {
        public T Value;
        public Node? Next;

        public Node(T value)
        {
            Value = value;
        }
    }

    public Node? Head { get; private set; }
    private Node? _tail;
    public int Count { get; private set; }

    public void AddList(T item)
    {
        var node = new Node(item);
        if (_tail is null)
        {
            Head = _tail = node;
        }
        else
        {
            _tail.Next = node;
            _tail = node;
        }
        Count++;
    }

    public void RemoveFirst()
    {
        if (Head is null)
            throw new InvalidOperationException("La lista está vacía");

        Head = Head.Next;
        if (Head is null)
            _tail = null;
        Count--;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (var current = Head; current is not null; current = current.Next)
            yield return current.Value;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
