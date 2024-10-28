public class Solution {
    public int LongestPalindrome(string s)
    {
        var ht = new Dictionary<char, int>();
        
        foreach (var c in s)
        {
            if (ht.ContainsKey(c)) ht[c]++;
            else ht.Add(c, 1);
        }

        var l = 0;
        
        var odd = false;
        
        foreach (var p in ht)
        {
            var val = p.Value;
            if (val % 2 == 0)
            {
                l += val;
            }
            else
            {
                l += val - 1;
                odd = true;
            }
        }

        l += odd ? 1 : 0;
        return l;
    }
}