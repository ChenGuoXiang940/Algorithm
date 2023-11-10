namespace _1_N所有質數
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool[] isprime = new bool[(int)1E2].Select(x => true).ToArray();
            for(int i = 2; i < 1E2; i++)
            {
                if (isprime[i])
                {
                    for(int j = i + i; j < 1E2; j += i)
                    {
                        isprime[j] = false;
                    }
                }
            }
            isprime[0] = isprime[1] = false;
            for(int i = 2; i < 1E2; i++)
            {
                if (isprime[i]) Console.WriteLine($"{i}");
            }
        }
    }
}