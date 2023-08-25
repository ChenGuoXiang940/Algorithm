namespace 硬幣問題
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int amount = int.Parse(Console.ReadLine() + "");
            int[] coins = (Console.ReadLine() + "").Split(' ').Select(x => int.Parse(x)).ToArray();
            int[] dp = new int[amount + 1];
            dp[0] = 1;
            foreach(int coin in coins)
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