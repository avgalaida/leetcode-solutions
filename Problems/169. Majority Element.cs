public class Solution {
    public int MajorityElement(int[] nums)
    {
        var ht = new Dictionary<int, int>();
        
        var majority = nums[0];
        foreach (var elem in nums)
        {
            if (!ht.TryAdd(elem, 1)) ht[elem]++;
            majority = ht[elem] > ht[majority] ? elem : majority;
        }
        
        return majority;
    }
}