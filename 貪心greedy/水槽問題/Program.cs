namespace 水槽問題
{
    internal class Program
    {
        //無隔板的水槽問題找最大容量
        static void Main(string[] args)
        {
            int[] h = new int[] { 3, 8, 5, 2, 7, 7, 3, 4 };
            int res = 0;
            int left = 0, right = h.Length - 1;
            while (left < right)
            {
                int cur_cap = Math.Min(h[left], h[right]) * (right - left);
                res = Math.Max(res, cur_cap);
                if (h[left] > h[right]) right--;
                else left++;
            }
            Console.WriteLine(res);
            Console.ReadKey();
        }
    }
}