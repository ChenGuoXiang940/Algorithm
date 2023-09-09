namespace 背包問題
{
    internal class Program
    {
        //具體來說是「0/1 背包問題」，其中每個物品只能選擇放入或不放入背包
        public static int knapsackWithPruning(int[] weights, int[] values, int capacity)
        {
            int len = weights.Length;
            int[,] dp = new int[len + 1, capacity + 1];
            //時間複雜度 O(len * capacity)
            //DP 紀錄每個狀態的最優解
            //遍歷每個物品以及每個可能的背包容量
            for (int i = 1; i <= len; i++)
            {
                for (int weight = 1; weight <= capacity; weight++)
                {
                    dp[i, weight] = dp[i - 1, weight];
                    //如果當前可以放入背包，當前狀態替換為價值較高的
                    if (weights[i - 1] <= weight)
                    {
                        dp[i, weight] = Math.Max(dp[i, weight], dp[i - 1, weight - weights[i - 1]] + values[i - 1]);
                    }
                }
            }
            return dp[len, capacity];
        }
        static void Main(string[] args)
        {
            int[] weights = new int[] { 2, 3, 4, 5, 9 };
            int[] values = new int[] { 3, 4, 5, 8, 10 };
            int capacity = 11;
            Console.WriteLine(knapsackWithPruning(weights, values, capacity));
            Console.ReadKey();
        }
    }
}