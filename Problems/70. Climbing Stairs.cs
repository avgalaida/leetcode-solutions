public class Solution {
    public int ClimbStairs(int n) {
        if (n == 1) return 1;

        var prev = 1;
        var curr = 1;

        for(int i = 2; i <= n; i++) {
            curr += prev;
            prev = curr - prev;
        }

        return curr;
    }
}