using System;

namespace _315Count_of_Smaller_Numbers_After_Self
{
    class SegmentTree
    {
        public int[] count;
        private void buildTree(ref int[] arr, ref List<int> orgindex, int left, int right)
        {
            if (left >= right) return;
            int mid = (left + right) / 2;
            buildTree(ref arr,ref orgindex,left, mid);
            buildTree(ref arr,ref orgindex,mid + 1, right);
            merge(ref arr,ref orgindex, left, mid, right);
        }
        private void merge(ref int[]arr, ref List<int> orgindex, int left,int mid,int right)
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
        public SegmentTree(int[]nums)
        {
            count = new int[nums.Length];
            List<int> orgindex = Enumerable.Range(0, nums.Length).ToList();
            buildTree(ref nums, ref orgindex, 0, nums.Length - 1);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 5, 2, 6, 1 };
            SegmentTree seg = new SegmentTree(nums);
            //在數組中，找出每個數字後面小於它的數字的個數
            Console.WriteLine(string.Join(" ", seg.count));
            Console.ReadKey();
        }
    }
}