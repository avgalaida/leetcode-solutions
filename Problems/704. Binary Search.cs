public class Solution {
    public int Search(int[] nums, int target) {
        var l = 0;
        var r = nums.Length - 1;

        while (r >= l) {
            var mid = l + (r - l) / 2;

            if (nums[mid] > target) {
                r = mid -1;
            }
            else if (nums[mid] < target)
            {
                l = mid + 1;
            }
            else {
                return mid;
            }
        }

        return -1;
    }
}