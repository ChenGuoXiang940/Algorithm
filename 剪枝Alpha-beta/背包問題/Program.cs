namespace 背包問題
{
    internal class Program
    {
        public static int knapsackWithPruning(int[] weights, int[] values, int capacity)
        {
            int len = weights.Length;
            int[,] dp = new int[len + 1, capacity + 1];
            //DP 紀錄每個狀態的最優解
            for (int i = 1; i <= len; i++)
            {
                for(int weight = 1; weight <= capacity; weight++)
                {
                    dp[i, weight] = dp[i - 1, weight];
                    //如果當前可以放入背包，當前狀態替換為 value 較高的
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
            int capacity = 10;
            Console.WriteLine(knapsackWithPruning(weights, values, capacity));
            Console.ReadKey();
        }
    }
}