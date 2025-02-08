namespace Brian_Kernighan_s位運算
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine() + "");
            string text = n.ToString();
            int times = 0;
            while (n > 0)
            {
                Console.WriteLine($"第{++times,2}次 {n,5}:{Convert.ToString(n, 2),10}   {n - 1,5}:{Convert.ToString(n - 1, 2),10}");
                n &= (n - 1);
            }
            Console.WriteLine($"{text}在二進制中為1的個數為{times}");
            Console.ReadKey();
        }
    }
}
/*  時間複雜度：O(k)，其中 k 是 n 的二進制表示中 1 的個數
 *  另一種壞方法:把數字轉字串再迴圈判斷數 1 的個數 O(m)，m 是 n 的轉字串的長度 */