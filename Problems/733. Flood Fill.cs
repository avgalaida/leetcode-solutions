public class Solution {
    public int[][] FloodFill(int[][] image, int sr, int sc, int color)
    {
        var originalColor = image[sr][sc];

        if (originalColor == color) 
            return image; 

        var m = image.Length;
        var n = image[0].Length;

        var st = new Stack<(int, int)>();
        
        st.Push((sr,sc));
        
        while (st.Count > 0)
        {
            var (i, j) = st.Pop();
            
            image[i][j] = color;

            if (i - 1 >= 0 && image[i - 1][j] == originalColor)
            {
                st.Push((i - 1, j));
            }

            if (i + 1 < m && image[i + 1][j] == originalColor)
            {
                st.Push((i + 1, j));
            }

            if (j - 1 >= 0 && image[i][j - 1] == originalColor)
            {
                st.Push((i, j - 1));
            }

            if (j + 1 < n && image[i][j + 1] == originalColor)
            {
                st.Push((i, j + 1));
            }

        }
        return image;
    }
}