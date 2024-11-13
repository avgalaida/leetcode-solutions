public class Solution {
    public int LengthOfLongestSubstring(string s)
    {
        var maxLen = 0;
        var indexMap = new int[128];  
        var left = 0;

        for (var right = 0; right < s.Length; right++)
        {
            var currChar = s[right];

            if (indexMap[currChar] >= left)
            {
                left = indexMap[currChar] + 1;
            }

            indexMap[currChar] = right; 
            maxLen = Math.Max(maxLen, right - left + 1);
        }

        return maxLen;
    }
}