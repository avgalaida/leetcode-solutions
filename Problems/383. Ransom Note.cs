public class Solution {
    public bool CanConstruct(string ransomNote, string magazine) {
        var ht = new Dictionary<char,int>();

        foreach (var note in ransomNote){
            if (ht.ContainsKey(note)) ht[note]++;
            else ht.Add(note,1);
        }

        foreach (var note in magazine){
            if (ht.ContainsKey(note)) ht[note]--;
        }

        foreach(var note in ht){
            if (note.Value > 0) return false;
        }

        return true;
    }
}