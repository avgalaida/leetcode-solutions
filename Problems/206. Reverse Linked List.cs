public class Solution
{
    public ListNode ReverseList(ListNode head)
    {
        if (head == null) return null;

        var st = new Stack<ListNode>();
        
        while (head.next != null)
        {
            st.Push(head);
            head = head.next;
        }

        var curr = head;

        while (st.Count > 0)
        {
            var node = st.Pop();
            curr.next = node;
            curr = curr.next;
        }
        
        curr.next = null;
        
        return head;
    }
}