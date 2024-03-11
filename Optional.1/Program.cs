using System.Collections;
public interface IMyList<in T>
{
    void Add(T t);
}

public class MyList<T> : IMyList<T>, IEnumerable
{
    private List<T> list = new List<T>();
    public void Add(T t)
    {
        list.Add(t);
    }

    public T this[int index]
    {
        get { return list[index]; }
        set { list[index] = value; }
    }

    public int Count { get { return list.Count; } }

    public IEnumerator GetEnumerator()
    {
        return list.GetEnumerator();
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

        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine(list[i]);
        }

        foreach (var l in list)
        {
            Console.WriteLine(l);
        }
    }
}

