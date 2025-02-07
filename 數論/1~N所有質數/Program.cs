namespace _1_N所有質數
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 100;
            bool[] isprime = new bool[n].Select(x => true).ToArray();
            for(int i = 2; i < n; i++)
            {
                if (isprime[i])
                {
                    for(int j = i + i; j < n; j += i)
                    {
                        isprime[j] = false;
                    }
                }
            }
            isprime[0] = isprime[1] = false;
            for(int i = 2; i < n; i++)
            {
                if (isprime[i]) Console.WriteLine($"{i}");
            }
        }
    }
}
/*  埃拉托色尼篩法，找出小於 100 的所有質數*/