public class Solution {
    public bool CanConstruct(string ransomNote, string magazine) {
        var count = new int[26];

        foreach (var ch in magazine) {
            count[ch - 'a']++;
        }

        foreach (var ch in ransomNote) {
            if (--count[ch - 'a'] < 0) {
                return false;
            }
        }

        return true;
    }
}