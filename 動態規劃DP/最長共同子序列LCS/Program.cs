namespace 最長共同子序列LCS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //時間複雜度 O(s1.Length * s2.Length)
            string s1 = "yaedfhrz";
            string s2 = "xabcdghxy";
            int[,] dp = new int[s1.Length + 1, s2.Length + 1];
            for (int i = 1; i <= s1.Length; i++)
            {
                for (int j = 1; j <= s2.Length; j++)
                {
                    if (s1[i - 1] == s2[j - 1]) dp[i, j] = dp[i - 1, j - 1] + 1;
                    else dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    Console.Write($"{dp[i, j]} ");
                }
                Console.Write('\n');
            }
            Console.WriteLine(dp[s1.Length, s2.Length]);
            Console.ReadKey();
        }
    }
}