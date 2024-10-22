public class Solution {
    public TreeNode InvertTree(TreeNode root)
    {
        if (root == null) return null;
        
        var rt = root;

        var st = new Stack<TreeNode>();
        st.Push(root);

        while (st.Count > 0)
        {
            var node = st.Pop();
            
            if (node.left != null) st.Push(node.left);
            if (node.right != null) st.Push(node.right);
            
            (node.left, node.right) = (node.right, node.left);
        }
        
        return rt;
    }
}