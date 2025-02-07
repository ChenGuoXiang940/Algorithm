namespace 最大公因數與最小公倍數
{
    internal class Program
    {
        public static int gcd1(int p,int q)
        {
            while (q != 0)
            {
                int tmp = q;
                q = p % q;
                p = tmp;
            }
            return p;
        }
        public static int lcm(int p,int q)
        {
            return p * q / gcd1(p, q);
        }
        public static int gcd2(int p,int q)
        {
            return q == 0 ? p : gcd2(q, p % q);
        }
        static void Main(string[] args)
        {
            while (true)
            {
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                Console.WriteLine($"gcd:{gcd1(a, b)},gcd2:{gcd2(a, b)},lcm:{lcm(a, b)}");
            }
        }
    }
}
/*  使用輾轉相除法計算 GCD，另外lcm(a,b)=a*b/gcd(a,b)   */
