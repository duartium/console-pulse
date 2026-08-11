using System.Collections;

// implementatión
var cola = new SimpleQueue<string>(3);
cola.Enqueue("A");
cola.Enqueue("B");
cola.Enqueue("C");
cola.Dequeue();
Console.WriteLine(cola.Peek());

foreach (var item in cola)
    Console.WriteLine(item);

public class SimpleQueue<T> : IEnumerable<T>
{
    private T[] _data;
    private int _head;
    private int _tail;
    private int _count;

    public SimpleQueue(int capacity)
    {
        _data = new T[capacity];
    }

    public void Enqueue(T item)
    {
        if (_count == _data.Length)
            throw new InvalidOperationException("La cola está llena");

        _data[_tail] = item;
        _tail = (_tail + 1) % _data.Length;
        _count++;
    }

    public T Dequeue()
    {
        if (_count == 0)
            throw new InvalidOperationException("La cola está vacía");

        T item = _data[_head];
        _data[_head] = default!;              // libera la referencia (ayuda al GC con tipos referencia)
        _head = (_head + 1) % _data.Length;   // avanza head con el mismo wrap-around
        _count--;
        return item;
    }

    public T Peek()
    {
        if (_count == 0)
            throw new InvalidOperationException("La cola está vacía");

        return _data[_head];   // lee, pero NO mueve head ni toca count
    }

        public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < _count; i++)
        {
            int index = (_head + i) % _data.Length;
            yield return _data[index];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}