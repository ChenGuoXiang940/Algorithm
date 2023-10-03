using System;

namespace _307Range_Sum_Query_Mutable
{
    public class NumArray
    {
        private int len;
        private int[] seg, arr;
        private void push(int id,int left,int right)
        {
            if (left == right)
            {
                seg[id] = arr[left];
                return;
            }
            int mid = (left + right) / 2;
            push(id * 2 + 1, left, mid);
            push(id * 2 + 2, mid + 1, right);
            seg[id] = seg[id * 2 + 1] + seg[id * 2 + 2];
        }
        private void update(int id,int left,int right,int pos,int val)
        {
            if (left == right)
            {
                seg[id] = val;//將 arr[left] 改 val
                return;
            }
            int mid = (left + right) / 2;
            //pos 以 mid 為基準進入左/右半邊(二分剪枝)
            if (pos <= mid) update(id * 2 + 1, left, mid, pos, val);
            else update(id * 2 + 2, mid + 1, right, pos, val);
            seg[id] = seg[id * 2 + 1] + seg[id * 2 + 2];//更新seg
        }
        private int query(int id,int left,int right,int query_left,int query_right)
        {
            if (left > query_right || right < query_left) return 0;
            if (query_left <= left && query_right >= right) return seg[id];
            int mid = (left + right) / 2;
            int res = 0;
            res += query(id * 2 + 1, left, mid, query_left, query_right);
            res += query(id * 2 + 2, mid + 1, right, query_left, query_right);
            return res;
        }
        public NumArray(int[] nums)
        {
            len = nums.Length;
            seg = new int[len << 2];
            arr = nums;
            push(0, 0, len - 1);
        }
        public void Update(int index, int val)
        {
            update(0, 0, len - 1, index, val);
            arr[index] = val;
        }
        public int SumRange(int left, int right) => query(0, 0, len - 1, left, right);
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 3, 5 };
            NumArray obj = new NumArray(nums);
            Console.WriteLine(obj.SumRange(0, 2)); // return 1 + 3 + 5 = 9
            obj.Update(1, 2);   // nums = [1, 2, 5]
            Console.WriteLine(obj.SumRange(0, 2)); // return 1 + 2 + 5 = 8
        }
    }
}