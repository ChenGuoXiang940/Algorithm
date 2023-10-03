using System;

namespace _315Count_of_Smaller_Numbers_After_Self
{
    class Seg
    {
        private int len;
        public int[] arr, count;
        private List<int> orgindex;
        private void build(int left,int right)
        {
            if (left>= right) return;
            int mid = (left + right) >> 1;
            build(left, mid);
            build(mid + 1, right);
            merge(left, mid, right);
        }
        private void merge(int left,int mid,int right)
        {
            int ls = mid - left + 1;
            int rs = right - mid;
            List<int> list_left = orgindex.GetRange(left, ls);
            List<int> list_right = orgindex.GetRange(mid + 1, rs);
            int i = 0, j = 0, k = left, jump = 0;
            while (i < ls && j < rs)
            {
                if (arr[list_left[i]] <= arr[list_right[j]])
                {
                    orgindex[k] = list_left[i];
                    count[list_left[i]] += jump;
                    i++;
                }
                else
                {
                    orgindex[k] = list_right[j];
                    jump++;
                    j++;
                }
                k++;
            }
            while (i < ls)
            {
                orgindex[k] = list_left[i];
                count[list_left[i]] += jump;
                i++;
                k++;
            }
            while (j < rs)
            {
                orgindex[k] = list_right[j];
                j++;
                k++;
            }
        }
        public Seg(int[]nums)
        {
            len = nums.Length;
            count = new int[len];
            arr = nums;
            int i = 0;
            orgindex = new int[len].Select(item => i++).ToList();
            build(0, len - 1);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 5, 2, 6, 1 };
            Seg seg = new Seg(nums);
            Console.WriteLine(string.Join(" ", seg.count));
            // orgindex : 3 1 0 2 表示 nums 位置的，比較值的大小降冪排序
            Console.ReadKey();
        }
    }
}