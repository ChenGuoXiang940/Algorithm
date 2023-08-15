namespace 硬幣問題
{
    internal class Program
    {
        public static void f(int amount,string text,int[]coins)
        {
            if (amount < 0) return;
            if (amount == 0)
            {
                Console.WriteLine(text.TrimEnd('+'));
                return;
            }
            foreach(int coin in coins)
            {
                f(amount - coin, text + coin.ToString() + "+", coins);
            }
        }
        static void Main(string[] args)
        {
            int amount = int.Parse(Console.ReadLine());
            int[] coins = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            //DP解
            int[] dp = new int[amount + 1];
            dp[0] = 1;
            foreach(int coin in coins)
            {
                for (int i = coin; i <= amount; i++)
                {
                    dp[i] += dp[i - coin];
                }
            }
            //回遞解
            f(amount, "", coins);
            Console.WriteLine("共有"+dp[amount]+"種硬幣組合(不考慮硬幣順序)");
            Console.ReadKey();
        }
    }
}