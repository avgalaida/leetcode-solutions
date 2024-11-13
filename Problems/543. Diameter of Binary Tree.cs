public class Solution {
    public int DiameterOfBinaryTree(TreeNode root) {
        var maxDiameter = 0;
        var stack1 = new Stack<TreeNode>();
        var stack2 = new Stack<TreeNode>();
        var depthMap = new Dictionary<TreeNode, int>();

        stack1.Push(root);

        while (stack1.Count > 0) {
            var node = stack1.Pop();
            stack2.Push(node);

            if (node.left != null) stack1.Push(node.left);
            if (node.right != null) stack1.Push(node.right);
        }

        while (stack2.Count > 0) {
            var node = stack2.Pop();
            var leftDepth = node.left != null ? depthMap[node.left] : 0;
            var rightDepth = node.right != null ? depthMap[node.right] : 0;

            maxDiameter = Math.Max(maxDiameter, leftDepth + rightDepth);

            depthMap[node] = Math.Max(leftDepth, rightDepth) + 1;
        }

        return maxDiameter;
    }
}