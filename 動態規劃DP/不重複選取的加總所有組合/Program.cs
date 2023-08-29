namespace 不重複選取的加總所有組合
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //時間複雜度 O(num.Length * sum)
            int[] num = { 4, 2, 2, 5 };
            int sum = num.Sum();
            int[] dp = new int[sum + 1];
            dp[0] = 1;//總和為 0 的方式有一種，即不選取任何元素
            foreach (int number in num)
            {
                for(int j = sum; j >= number; j--)
                {
                    dp[j] += dp[j - number];
                }
            }
            int result = 0;
            //列印所有可能的總和
            for (int i = 1; i <= sum; i++)
            {
                if (dp[i] > 0)
                {
                    Console.Write($"{i} ");
                    result++;
                }
            }
            Console.WriteLine("共有:" + result.ToString()+"個");
            Console.ReadKey();
        }
    }
}