namespace 最長的嚴格遞增子序列
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //20 40 32 67 40 20 89 300 404 13 13
            int[] num = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            //DP解
            int[] dp = new int[num.Length].Select(x => 1).ToArray();//自己算一個
            for (int i = 1; i < num.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (num[i] > num[j]) dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
            Console.WriteLine(dp.Max());
            Console.ReadKey();
        }
    }
}