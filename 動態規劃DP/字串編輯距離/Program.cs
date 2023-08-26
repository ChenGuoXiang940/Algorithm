namespace 字串編輯距離
{
    internal class Program
    {
        public struct Data
        {
            public int val;
            public string record;
        }
        public static void cmp(ref Data cur,Data a,Data b,Data c)
        {
            int minval = Math.Min(a.val, Math.Min(b.val, c.val));
            if (minval == c.val)
            {
                cur.val += c.val;
                cur.record = c.record + "刪除一個字元\r\n";
            }
            else if(minval == b.val)
            {
                cur.val += b.val;
                cur.record = b.record + "添加一個的字元\r\n";
            }
            else
            {
                cur.val += a.val;
                cur.record = a.record + "替換字符串中的一個字元\r\n";
            }
        }
        static void Main(string[] args)
        {
            //字串最小編輯距離
            //距離是唯一 但過程可能不只一種解 輸出其中一種
            string s1 = "intention";
            string s2 = "execution";
            Data[,] dp = new Data[s1.Length + 1, s2.Length + 1];
            for (int i = 0; i <= s1.Length; i++)
            {
                dp[i, 0].val = i;
            }
            for (int i = 0; i <= s2.Length; i++)
            {
                dp[0, i].val = i;
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
                        cmp(ref dp[i, j], dp[i - 1, j - 1], dp[i, j - 1], dp[i - 1, j]);
                        dp[i, j].val += 1;
                    }
                }
            }
            Console.WriteLine(dp[s1.Length, s2.Length].record + "最小編輯距離:" + dp[s1.Length, s2.Length].val.ToString());
            Console.ReadKey();
        }
    }
}