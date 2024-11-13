public class Solution
{
    public int MaxSubArray(int[] nums)
    {
        var sum = 0;
        var maxSum = nums[0];

        foreach (var num in nums)
        {
            if (sum < 0) sum = 0;
            sum += num;
            if (sum > maxSum) maxSum = sum;
        }

        return maxSum;
    }
}