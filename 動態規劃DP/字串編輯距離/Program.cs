namespace 字串編輯距離
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //時間複雜度 O(n + m)
            string s1 = "intention";
            string s2 = "execution";
            int[,] dp = new int[s1.Length + 1, s2.Length + 1];
            for (int i = 0; i <= s1.Length; i++)
            {
                dp[i, 0] = i;
            }
            for (int i = 0; i <= s2.Length; i++)
            {
                dp[0, i] = i;
            }
            for (int i = 1; i <= s1.Length; i++)
            {
                for (int j = 1; j <= s2.Length; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = Math.Min(dp[i - 1, j - 1], Math.Min(dp[i, j - 1], dp[i - 1, j])) + 1;
                    }
                }
            }
            Console.WriteLine(dp[s1.Length, s2.Length]);
            Console.ReadKey();
        }
    }
}