public class Solution
{
    public int MaxProfit(int[] prices)
    {
        var minPrice = prices[0];
        var maxProfit = 0;

        foreach (var price in prices)
        {
            maxProfit = Math.Max(maxProfit, price - minPrice);
            minPrice = Math.Min(minPrice, price);
        }

        return maxProfit; 
    }
}