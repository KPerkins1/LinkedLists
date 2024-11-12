namespace LinkedListLab;

public class Program
{
    static void Main(string[] args)
    {
        IAmAList<int> myList = new MyLinkedList<int>();
        myList.Add(1);
        myList.Add(2);
        myList.Add(3);
        myList.Add(4);
        myList.Add(5);

        Console.WriteLine(myList.GetValue(0));
        Thread.Sleep(1000);

    }
}


/// <summary>
/// The interface IAmAList lists all variables to be used by MyLinkedList. 
/// </summary>
/// <typeparam name="T"> Generics </typeparam>
public interface IAmAList<T>
{
    /// <summary>
    /// Will add data to the list
    /// </summary>
    public void Add(T data) { }

    /// <summary>
    /// Will remove data from the list
    /// </summary>
    public void Remove(T data) { }

    /// <summary>
    /// Will add data to the list at a certain index.
    /// </summary>
    public void InsertAtIndex (T data, int index) { }

    /// <summary>
    /// Will remove data to the list at a certain index.
    /// </summary>
    public void RemoveAtIndex(int index) { }

    public void Display();

    public void Clear();

    public bool Contains(T data);

    public T GetValue(int index);

}

public class myNode<T>
{
    public T data;

    public myNode<T> next;

    public myNode<T> prev;

    public myNode(T data)
    {
        this.data = data;
    }
}

public class MyLinkedList<T> : IAmAList<T>
{
    public myNode<T> head;

    public myNode<T> tail;

    public int Count;

    public void Add(T data)
    {
        
        if (Count == 0)
        {
            head = new myNode<T>(data);
            tail = head;
            Count++;
            return;
        }

        tail.next = new myNode<T>(data);
        tail.next.prev = tail;
        this.tail = tail.next;
        Count++;
    }

    public void Remove(T data)
    {
        if (Count == 0)
        {
            return;
        }

        myNode<T> current = head;

        if (current.data.Equals(data))
        {
            head = head.next;
            if (head != null)
            {
                head.prev = null;
            }

            else
            {
                tail = null;
            }

            Count--;
            return;
        }
    }


    public void Clear()
    {
        head = null;
        tail = null;
        Count = 0;
    }

    public bool Contains(T data)
    {
        var current = head;
        while (current != null)
        {
            if (current.data.Equals(data))
            {
                return true;
            }
            current = current.next;
        }
        return false;
    }

    public void Display()
    {
        var current = head;

        while (current != null)
        {
            Console.WriteLine(current);
            current = current.next;
        }
    }

    public T GetValue(int index)
    {
        var current = head;
        for (int i = 0; i < index-1; i++)
        {
            current = current.next;
        }
        return current.data;
    }

    public void InsertAtIndex(T data, int index)
    {
        if (index < 0 || index > Count)
        {
            throw new ArgumentOutOfRangeException("Index is out of range.");
        }
        myNode<T> newNode = new myNode<T>(data);

        if (index == 0)
        {
            newNode.next = head;

            if (head != null)
            {
                head.prev = newNode;
            }
            head = newNode;

            if (tail == null)
            {
                tail = newNode;
            }
        }

        else if (index == Count)
        {
            tail.next = newNode;
            newNode.prev = tail;
            tail = newNode;
        }

        else
        {
            myNode<T> current = head;
            for(int i = 0; i < index; i++)
            {
                current = current.next;
            }
            newNode.prev = current.prev;
            newNode.next = current;
            current.prev.next = newNode;
            current.prev = newNode;
        }

        Count++;
    }

    public void RemoveAtIndex(int index)
    {
        var currentNode = head;
        int currentIndex = 0;
        while (currentNode != null && currentIndex <
            Count && !(currentIndex == index))
        {
            currentNode = currentNode.next;
        }

        currentNode.prev.next = currentNode.next;
        currentNode.next.prev = currentNode.prev;
    }
}
