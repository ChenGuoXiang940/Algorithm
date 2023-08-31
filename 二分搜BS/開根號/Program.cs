namespace 開根號
{
    internal class Program
    {
        public static long bs(long left,long right,long key)
        {
            if (left > right) return right;
            long mid = left + (right - left) / 2;
            if (mid * mid == key) return mid;
            else if (mid * mid < key) return bs(mid + 1, right, key);
            else return bs(left, mid - 1, key);
        }
        static void Main(string[] args)
        {
            int x = 8;
            Console.WriteLine(bs(0, 25536, x));
            Console.ReadKey();
        }
    }
}