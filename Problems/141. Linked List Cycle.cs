public class Solution {
    public bool HasCycle(ListNode head)
    {
        var d = new Dictionary<ListNode, int>();

        var curr = head;
        var pos = 0;
        
        while (curr != null)
        {
            if (d.ContainsKey(curr))
            {
                
                if (d[curr] < pos ) return true;
            }
            else
            {
                d.Add(curr,pos);
            }
            pos += 1;
            curr = curr.next;
        }
        
        return false;
    }
}