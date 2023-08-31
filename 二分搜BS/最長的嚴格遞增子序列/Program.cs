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
            List<int> tails = new List<int>() { nums[0] };
            for(int i=1;i<nums.Length; i++)
            {
                //找到了一個比 tails 串列中的所有元素都大的 num，遞增子序列的末端新增一個元素
                if (tails.Last() < nums[i])
                {
                    tails.Add(nums[i]);
                }
                else
                {
                    int left = 0;
                    int right = tails.Count - 1;
                    while (left < right)
                    {
                        int mid = left + (right - left) / 2;
                        if (tails[mid] < nums[i]) left = mid + 1;
                        else right = mid;
                    }
                    tails[left] = nums[i];
                }
            }
            Console.WriteLine(tails.Count);
            Console.WriteLine(string.Join(",", tails.ToArray()));
            Console.ReadKey();
        }
    }
}