namespace 硬幣問題
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //時間複雜度 O(amount * coins.length) 硬幣數量無限
            //在計算組合總數時非常高效，適用於類似找零、組合等問題
            //該演算法並不需要回溯搜索，因此它與回溯法和剪枝法無關
            int amount = 10;
            int[] coins = new int[] { 1, 5, 10, 50 };
            int[] dp = new int[amount + 1];
            dp[0] = 1;
            //遍歷每個硬幣以及每個可能的硬幣組合
            foreach (int coin in coins)
            {
                for (int i = coin; i <= amount; i++)
                {
                    dp[i] += dp[i - coin];
                }
            }
            Console.WriteLine(dp[amount]);
            Console.ReadKey();
        }
    }
}