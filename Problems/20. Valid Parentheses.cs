public class Solution {
    public bool IsValid(string s)
{ 
    if (s.Length < 2) return false;

    var pairs = new Dictionary<char, char>
    {
        { '(', ')' },
        { '[', ']' },
        { '{', '}' }
    };

    var st = new Stack<Char>();

    foreach (var c in s)
    {
        if (pairs.ContainsKey(c))
        {
            st.Push(c);
        }
        else
        {
            if (st.Count == 0 || pairs[st.Pop()] != c) return false;
        }
    }

    return st.Count == 0;
}
}