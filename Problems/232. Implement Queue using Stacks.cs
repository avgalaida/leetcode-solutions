public class MyQueue {
    Stack<int> st1, st2;

    public MyQueue() {
        st1 = new Stack<int>();
        st2 = new Stack<int>();
    }
    
    public void Push(int x) {
        st1.Push(x);
    }
    
    public int Pop() {
        while (st1.Count > 0){
            st2.Push(st1.Pop());
        }

        var val = st2.Pop();

        while (st2.Count > 0){
            st1.Push(st2.Pop());
        }

        return val;
    }
    
    public int Peek() {
        while (st1.Count > 0){
            st2.Push(st1.Pop());
        }

        var val = st2.Peek();

        while (st2.Count > 0){
            st1.Push(st2.Pop());
        }
        
        return val;
    }
    
    public bool Empty() {
        return st1.Count == 0;
    }
}
