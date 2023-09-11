namespace 幾步內最短路徑
{
    internal class Program
    {
        public static List<List<(int, int)>> map = new List<List<(int,int)>>();
        static void Main(string[] args)
        {
            int citys = 6;
            int steps = 2;
            //輸出從城市編號 0 走到城市編號 citys-1，最少要花多少錢。
            //設定單向圖的長度
            for (int i = 0; i < 1E5; i++) map.Add(new List<(int, int)>());
            //map[u]=(v,w)，分別代表；起點、終點、過路費。
            map[0].Add((1, 1));
            map[0].Add((2, 6));
            map[1].Add((3, 1));
            map[1].Add((4, 5));
            map[2].Add((5, 7));
            map[3].Add((5, 1));
            //用來存儲計算結果
            int[,] dp = new int[citys, steps + 1];
            for (int i = 0; i < citys; i++)
            {
                for (int j = 0; j <= steps; j++)
                {
                    dp[i, j] = int.MaxValue;
                }
            }
            //因為在起始城市時，不需要花費
            dp[0, 0] = 0;
            for (int step = 0; step <= steps; step++)
            {
                for (int city = 0; city < citys; city++)
                {
                    if (dp[city, step] == int.MaxValue) continue;
                    foreach(var neighbor in map[city])
                    {
                        if (step + 1 <= steps)
                        {
                            int city_next = neighbor.Item1;
                            int neighbor_cost = neighbor.Item2;
                            //下一個節點為 0 到當前節點的花費加上當前到此節點的花費，取最小
                            dp[city_next, step + 1] = Math.Min(dp[city_next, step + 1], dp[city, step] + neighbor_cost);
                        }
                    }
                }
            }
            //對於所有可能的步數，找到到達目標城市的最小花費
            int result = int.MaxValue;
            for (int step = 0; step <= steps; step++)
            {
                result = Math.Min(result, dp[citys - 1, step]);
            }
            Console.WriteLine(result == int.MaxValue ? "不存在" : result.ToString());
            Console.ReadKey();
        }
    }
}