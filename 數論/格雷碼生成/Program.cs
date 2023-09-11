namespace 格雷碼生成
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("請輸入格雷碼位元: ");
            int n = int.Parse(Console.ReadLine() + "");
            if (n <= 0)
            {
                Console.WriteLine("請輸入正整數.");
                return;
            }
            int N = (int)Math.Pow(2, n);
            for(int i = 0; i < N; i++)
            {
                Console.WriteLine($"{i} : " + Convert.ToString(i ^ (i >> 1), 2).PadLeft(n, '0'));
            }
            Console.ReadKey();
        }
    }
}