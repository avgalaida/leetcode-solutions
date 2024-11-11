public class Solution
{
    public ListNode ReverseList(ListNode head)
    {
        ListNode prev = null;
        var curr = head;

        while (curr != null)
        {
            var next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }

        return prev;
    }
}