namespace 卡特蘭數
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] c = new int[10];
            c[0] = 1;
            for (int i = 1; i < 10; ++i)
            {
                c[i] = 0;
                for (int j = 0; j < i; ++j)
                {
                    c[i] += c[j] * c[i - 1 - j];
                }
            }
            Console.WriteLine(string.Join(" ", c));
        }
    }
}
/*  動態規劃 c[i] = Σ (c[j] * c[i-1-j])   */