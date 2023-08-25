namespace 快速冪
{
    internal class Program
    {
        public static double pow1(double n,int m)
        {
            double r = 1;
            while (m != 0)
            {
                if ((m & 1) == 1)
                {
                    r = r * n;
                }
                n = n * n;
                m >>= 1;
            }
            return r;
        }
        public static double pow2(double n,int m)
        {
            if (m == 0) return 1;
            if (m == 1) return n;
            if ((m % 2) == 1) return n * pow2(n * n, m / 2);
            return pow2(n * n, m / 2);
        }
        static void Main(string[] args)
        {
            double n = 3;
            int m = 10;
            //迴圈解
            Console.WriteLine($"{(m < 0 ? 1 / pow1(n, -m) : pow1(n, m))}");
            //遞迴解 較快
            Console.WriteLine($"{(m < 0 ? 1 / pow2(n, -m) : pow2(n, m))}");
            Console.ReadKey();
        }
    }
}