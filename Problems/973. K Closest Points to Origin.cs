public class Solution
{
    public int[][] KClosest(int[][] points, int k)
    {
        int left = 0, right = points.Length - 1;
        
        while (true)
        {
            int pivotIndex = Partition(points, left, right);

            if (pivotIndex == k) break;
            if (pivotIndex < k)
            {
                left = pivotIndex;
            }
            else
            {
                right = pivotIndex - 1;
            }
        }

        var result = new int[k][];
        Array.Copy(points, result, k);
        return result;
    }

    private int Partition(int[][] points, int left, int right)
    {
        int[] pivot = points[left + (right - left) / 2];
        int pivotDist = SquaredDistance(pivot);

        while (left <= right)
        {
            while (SquaredDistance(points[left]) < pivotDist) left++;
            while (SquaredDistance(points[right]) > pivotDist) right--;

            if (left <= right)
            {
                Swap(points, left, right);
                left++;
                right--;
            }
        }

        return left;
    }

    private int SquaredDistance(int[] point)
    {
        return point[0] * point[0] + point[1] * point[1];
    }

    private void Swap(int[][] points, int i, int j)
    {
        var temp = points[i];
        points[i] = points[j];
        points[j] = temp;
    }
}