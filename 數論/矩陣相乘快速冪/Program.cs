namespace 矩陣相乘快速冪
{
    internal class Program
    {
        public static ulong[] mult(ulong[] a, ulong[] b)
        {
            return new ulong[4]
            {
                a[0]*b[0]+a[1]*b[2],
                a[0]*b[1]+a[1]*b[3],
                a[2]*b[0]+a[3]*b[2],
                a[2]*b[1]*a[3]*b[3]
            };
        }
        static void Main(string[] args)
        {
            int n, rd;
            while (true)
            {
                Console.Write("N=");
                if (!int.TryParse(Console.ReadLine(), out n) || n < 1 || n > 90)
                {
                    Console.WriteLine("輸入值介於1~90!");
                    continue;
                }
                rd = n;
                n -= 2;
                ulong[] ans = new ulong[] { 1, 1, 1, 0 };
                ulong[] m = new ulong[] { 1, 1, 1, 0 };
                while (n > 0)
                {
                    ans = ((n & 1) == 1) ? mult(ans, m) : ans;
                    m = mult(m, m);
                    n >>= 1;
                }
                Console.WriteLine($"費式數列第{rd}個={ans[0]}");
            }
        }
    }
}