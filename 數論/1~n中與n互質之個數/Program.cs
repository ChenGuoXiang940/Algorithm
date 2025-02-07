using System.Collections.Generic;

namespace _1_n中與n互質之個數
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            while (true)
            {
                n = int.Parse(Console.ReadLine() + "");
                HashSet<double> primes = new HashSet<double>();
                int cnt = 2;
                double res = n;
                while (cnt <= n)
                {
                    if (n % cnt == 0)
                    {
                        n /= cnt;
                        primes.Add(cnt);
                    }
                    else
                    {
                        cnt++;
                    }
                }
                foreach(double p in primes)
                {
                    res *= (1 - (1.0 / p));
                }
                //10 有 1、3、7、9 與之互質
                Console.WriteLine($"共有 {(int)res} 個與 n 互質");
            }
        }
    }
}
/*  計算歐拉函數  */