public class MyQueue
{
    Stack<int> st1, st2;

    public MyQueue()
    {
        st1 = new Stack<int>();
        st2 = new Stack<int>();
    }

    public void Push(int x)
    {
        st1.Push(x);
    }

    public int Pop()
    {
        if (st2.Count == 0)
        {
            while (st1.Count > 0)
            {
                st2.Push(st1.Pop());
            }
        }

        return st2.Pop();
    }

    public int Peek()
    {
        if (st2.Count == 0)
        {
            while (st1.Count > 0)
            {
                st2.Push(st1.Pop());
            }
        }

        return st2.Peek();
    }

    public bool Empty()
    {
        return st1.Count == 0 && st2.Count == 0;
    }
}