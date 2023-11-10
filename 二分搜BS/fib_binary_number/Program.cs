namespace fib_binary_number
{
    internal class Program
    {
        public static List<ulong> num = new List<ulong>() { 1, 1 };
        public static int bs(int left,int right,ulong key)
        {
            if (left > right) return right;
            int mid = left + (right - left) / 2;
            if (key == num[mid]) return mid;
            else if (key > num[mid]) return bs(mid + 1, right, key);
            else return bs(left, mid - 1, key);
        }
        static void Main(string[] args)
        {
            for(int i = 1; num.Last() <= 1E8; i++)
            {
                num.Add(num.Last() + num[num.Count - 2]);
            }
            int cnt = 1;
            while (true)
            {
                ulong n = ulong.Parse(Console.ReadLine() + "");
                if (n == 0) break;
                ulong head = n;
                int index = bs(1, num.Count - 1, n);
                string res = "";
                for (int i = index; i >= 1; i--)
                {
                    if (head >= num[i])
                    {
                        res += "1";
                        head -= num[i];
                    }
                    else
                    {
                        res += "0";
                    }
                }
                Console.WriteLine($"#{cnt++}:{n}={res}(fib)");
            }
        }
    }
}