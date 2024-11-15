public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        var res = new List<IList<int>>();
        Array.Sort(nums);

        var n = nums.Length;

        for (var curr = 0; curr < n - 2; curr++)
        {
            if (nums[curr] > 0) break;

            if (curr > 0 && nums[curr] == nums[curr - 1]) continue;

            int left = curr + 1, right = n - 1;

            while (left < right)
            {
                var sum = nums[curr] + nums[left] + nums[right];

                if (sum == 0)
                {
                    res.Add(new int[] { nums[curr], nums[left], nums[right] });

                    while (left < right && nums[left] == nums[left + 1]) left++;
                    while (left < right && nums[right] == nums[right - 1]) right--;

                    left++;
                    right--;
                }
                else if (sum < 0)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
        }

        return res;
    }
}