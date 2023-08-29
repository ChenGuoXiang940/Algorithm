using System;

namespace 最長的嚴格遞增子序列
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //時間複雜度 O(n log n)
            //tails[i] 表示長度為 i+1 的遞增子序列的最末元素的最小值
            //遍歷到一個新的數字時，我們將其插入到 tails 陣列中適當的位置，從而保證 tails 陣列始終是遞增
            int[] nums = new int[] { 20, 40, 32, 67, 40, 20, 89, 300, 404, 13, 13 };
            int len = nums.Length;
            int[] tails = new int[len];
            int size = 0;
            foreach (int num in nums)
            {
                int left = 0, right = size;
                while (left < right)
                {
                    int mid = left + (right - left) / 2;
                    if (tails[mid] < num)
                        left = mid + 1;
                    else
                        right = mid;
                }
                tails[left] = num;
                if (left == size) size++;
            }
            Console.WriteLine(size);
            var nonZeroElements = tails.TakeWhile(element => element != 0);
            Console.WriteLine(string.Join(",", nonZeroElements));
            Console.ReadKey();
        }
    }
}