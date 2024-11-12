public class Solution {
    public int MaxDepth(TreeNode root)
    {
        if (root == null) return 0;
        
        var maxDepth = 0;
        var stack = new Stack<(TreeNode node, int currentDepth)>();
        
        stack.Push((root, 1));
        while (stack.Count > 0)
        {
            var (node, currentDepth) = stack.Pop();
            
            if (currentDepth > maxDepth) 
                maxDepth = currentDepth;
            
            if (node.left != null) 
                stack.Push((node.left, currentDepth + 1));
                
            if (node.right != null) 
                stack.Push((node.right, currentDepth + 1));
        }
        
        return maxDepth;
    }
}