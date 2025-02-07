namespace 模反元素
{
    internal class Program
    {
        public static int pow(int a,int b)
        {
            int c = 1;
            while (b != 0)
            {
                if ((b & 1) == 1) c = c * a;
                a = a * a;
                b >>= 1;
            }
            return c;
        }
        static void Main(string[] args)
        {
            Console.Write("一個質數p:");
            int p = int.Parse(Console.ReadLine());
            Console.Write("一個數a:");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine($"a^(p-2):{pow(a, p - 2)},乘法反元素:{pow(a, p - 2) % p}");
        }
    }
}
/*計算 a 在模 𝑝 下的乘法反元素，即求 ax=1(mod p) */