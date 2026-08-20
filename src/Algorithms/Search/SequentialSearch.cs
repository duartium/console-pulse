// Ejemplo de ejecucion con verificacion rapida
var st = new SequentialSearchSt<string, int>();
st.Add("A", 1);
st.Add("B", 2);
st.Add("A", 10); // actualiza el valor existente

if (st.Count != 2) throw new Exception("Count deberia ser 2");
if (!st.TryGet("A", out var value) || value != 10) throw new Exception("TryGet deberia devolver 10 para 'A'");
if (st.Contains("C")) throw new Exception("No deberia contener 'C'");

if (!st.Remove("B")) throw new Exception("Remove deberia devolver true para 'B'");
if (st.Contains("B")) throw new Exception("No deberia contener 'B' despues de removerlo");
if (st.Count != 1) throw new Exception("Count deberia ser 1 despues de remover 'B'");
if (st.Remove("Z")) throw new Exception("Remove deberia devolver false para clave inexistente");

Console.WriteLine("Verificacion OK");
Console.WriteLine($"A = {value}");
Console.WriteLine("Keys: " + string.Join(", ", st.Keys()));

public class SequentialSearchSt<TKey, TValue>
{
    private class Node {
        public TKey key { get; }
        public TValue value { get; set; }
        public Node next { get; set; }
        public Node(TKey key, TValue value, Node next)
        {
            this.key = key;
            this.value = value;
            this.next = next;
        }
    }
    private Node _first;
    private readonly EqualityComparer<TKey> _comparer;
    public int Count { get; private set; }
    public SequentialSearchSt()
    {
        _comparer = EqualityComparer<TKey>.Default;
    }
    public SequentialSearchSt(EqualityComparer<TKey> comparer)
    {
        _comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
    }
    public bool TryGet(TKey key, out TValue val)
    {
        for(Node x = _first; x != null; x = x.next)
        {
            if(_comparer.Equals(key, x.key))
            {
                val = x.value;
                return true;
            }
        }
        val = default(TValue);
        return false;
    }
    public void Add(TKey key, TValue val)
    {
        if(key == null)
            throw new ArgumentNullException(nameof(key));

        for(Node x = _first; x != null; x = x.next)
        {
            if(_comparer.Equals(x: key, y: x.key))
            {
                x.value = val;
                return;
            }
        }
        _first = new Node(key, val, _first);
        Count++;
    }

    public bool Contains(TKey key)
    {
        if(key == null)
            throw new ArgumentNullException(nameof(key));

        for(Node x = _first; x != null; x = x.next)
        {
            if(_comparer.Equals(x: key, y: x.key))
                return true;
        }
        return false;
    }

    public IEnumerable<TKey> Keys()
    {
        for(Node x = _first; x != null; x = x.next)
            yield return x.key;
    }

    public bool Remove(TKey key)
    {
        if(key == null)
            throw new ArgumentNullException(nameof(key));
        if(Count == 1 && _comparer.Equals(x: key, y: _first.key))
        {
            _first = null;
            Count--;
            return true;
        }
        
        Node prev = null;
        Node current = _first;

        while(current != null)
        {
            if(_comparer.Equals(current.key, key))
            {
                if(prev == null)
                {
                    _first = current.next;
                }
                else
                {
                    prev.next = current.next;
                }
                Count--;
                return true;
            }
            
            prev = current;
            current = current.next;
        }
        return false;
    }
    
}
