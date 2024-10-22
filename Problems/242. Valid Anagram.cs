public class Solution {
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length) return false;

        var d = new Dictionary<int, int>(26);

        for (var i = 0; i < s.Length; i++)
        {
            d[s[i] - 97] = d.GetValueOrDefault(s[i] - 97) + 1;
            d[t[i] - 97] = d.GetValueOrDefault(t[i] - 97) - 1;
        }

        foreach (var pair in d)
        {
            if (pair.Value != 0) return false;
        }

        return true;
    }
}