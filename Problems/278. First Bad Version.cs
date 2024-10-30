public class Solution : VersionControl {
    public int FirstBadVersion(int n) {
        var l = 1;
        var r = n;

        while (r >= l){
            var mid = l + (r-l)/2;

            if (IsBadVersion(mid)){
                r = mid - 1;
            }
            else {
                l = mid + 1;
            }
        }

        return l;
    }
}