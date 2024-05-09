using System.Collections;
public interface IMyList<in T>
{
    void Add(T t);
}

public class MyList<T> : IMyList<T>, IEnumerable
{
    private const int DefaultCapacity = 5;
    private T[] _items = new T[DefaultCapacity];
    private int _index;

    public void Add(T t)     //It's ok
    {
        _items[_index] = t;    
        _index++;
    }

    public T this[int index]
    {
        get { return _items[index]; }
        set { _items[index] = value; }
    }

    public IEnumerator GetEnumerator()
    {
        return _items.GetEnumerator();  //It's ok
    }

    public T[] ResizeArray(int newSize)
    {
        if(newSize < 0)
        {
            throw new ArgumentOutOfRangeException("Array's size must not be smaller 0");
        }

        T[] newArray = new T[newSize];
        Array.Copy(_items, newArray, Math.Min(_items.Length, newSize)); 
        _items = newArray;

        return _items;
    }
}


internal class Program
{
    private static void Main()
    {
        var list = new MyList<int>();

        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);
        list.Add(5);

        foreach (var l in list)
        {
            Console.WriteLine($"l is {l}");
        }
        Console.WriteLine();


        //New size
        list.ResizeArray(10);

        foreach (var l in list)
        {
            Console.WriteLine($"l of newSize is {l}");
        }
    }
}

