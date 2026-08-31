// Ejemplo de ejecucion con verificacion rapida
var set = new ChainhashSet<string, int>(4);
set.Add("A", 1);
set.Add("B", 2);
set.Add("C", 3);

if (set.Count != 3) throw new Exception("Count deberia ser 3");
if (!set.Contains("A")) throw new Exception("Deberia contener 'A'");
if (set.Get("B") != 2) throw new Exception("Get deberia devolver 2 para 'B'");

set.Add("A", 10); // actualiza el valor existente
if (set.Get("A") != 10) throw new Exception("Get deberia devolver 10 para 'A' tras actualizar");
if (set.Count != 3) throw new Exception("Count no deberia cambiar al actualizar una clave existente");

if (!set.Remove("B")) throw new Exception("Remove deberia devolver true para 'B'");
if (set.Contains("B")) throw new Exception("No deberia contener 'B' despues de removerlo");
if (set.Remove("Z")) throw new Exception("Remove deberia devolver false para clave inexistente");

Console.WriteLine("Verificacion OK");
Console.WriteLine("Keys: " + string.Join(", ", set.Keys()));

public class ChainhashSet<TKey, TValue>
{
    private SequentialSearchSt<TKey, TValue>[] _chains;
    private const int DefaultCapacity = 4;
    public int Count { get; private set; }
    public int Capacity { get; private set; }

    public ChainhashSet(int capacity = DefaultCapacity)
    {
        Capacity = capacity;
        _chains = new SequentialSearchSt<TKey, TValue>[capacity];
        for (int i = 0; i < capacity; i++)
        {
            _chains[i] = new SequentialSearchSt<TKey, TValue>();
        }
    }

    private int Hash(TKey key)
    {
        return (key.GetHashCode() & 0x7fffffff) % Capacity;
    }

    public TValue Get(TKey key)
    {
        if(key == null)
            throw new ArgumentNullException(nameof(key));

        int index = Hash(key);
        if(_chains[index].TryGet(key, out TValue val))
        {
            return val;
        }
        throw new KeyNotFoundException($"Key '{key}' not found.");
    }

    public bool Contains(TKey key)
    {
        if(key == null)
            throw new ArgumentNullException(nameof(key));

        int index = Hash(key);
        return _chains[index].Contains(key);
    }

    public bool Remove(TKey key)
    {
        if(key == null)
            throw new ArgumentNullException(nameof(key));

        int index = Hash(key);
        if(_chains[index].Remove(key))
        {
            Count--;
            return true;
        }
        return false;
    }
    public void Add(TKey key, TValue value)
    {
        if(key == null)
            throw new ArgumentNullException(nameof(key));

        if(value == null)
        {
            Remove(key);
            return;
        }

        if(Count >= 10 * Capacity) Resize(2 * Capacity);

        int index = Hash(key);
        if(!_chains[index].Contains(key))
        {
            Count++;
        }
        _chains[index].Add(key, value);
    }

    private void Resize(int chains)
    {
        var temp = new ChainhashSet<TKey, TValue>(chains);
        for (int i = 0; i < Capacity; i++)
        {
            foreach (TKey key in _chains[i].Keys())
            {
                if(_chains[i].TryGet(key, out TValue val))
                {
                    temp.Add(key, val);
                }
            }
        }

        Capacity = temp.Capacity;
        Count = temp.Count;
        _chains = temp._chains;
    }

    public IEnumerable<TKey> Keys()
    {
        var queue = new Queue<TKey>();
        for (int i = 0; i < Capacity; i++)
        {
            foreach (TKey key in _chains[i].Keys())
            {
                queue.Enqueue(key);
            }
        }
        return queue;
    }
}