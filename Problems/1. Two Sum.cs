public class Solution {
    public int[] TwoSum(int[] nums, int target)
    {
        var res = new int[2];

        var dict = new Dictionary<int, int>();
        
        for (var i = 0; i < nums.Length; i++)
        {
            var pivot = target - nums[i];

            if (dict.TryGetValue(pivot, out var idx))
            {
                (res[0], res[1]) = (i, idx);
                break;
                
            }
            dict[nums[i]] = i;
        }

        return res;
    }
}