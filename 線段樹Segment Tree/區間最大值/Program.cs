﻿namespace 區間最大值
{
    class Seg
    {
        private int len;
        private int[] seg, arr;
        private void push(int id,int left,int right)
        {
            if (left == right)
            {
                seg[id] = arr[left];// 節點對應的區間是[id,id]
                return;
            }
            int mid = (left + right) >> 1;
            push(id * 2 + 1, left, mid);
            push(id * 2 + 2, mid + 1, right);
            seg[id] = Math.Max(seg[id * 2 + 1], seg[id * 2 + 2]);
        }
        private int query(int id,int left,int right,int q_left,int q_right)
        {
            if (left > q_right || right < q_left) return 0;
            if (q_left <= left && right <= q_right) return seg[id];
            int mid = (left + right) >> 1;
            if (q_right <= mid) return query(id * 2 + 1, left, mid, q_left, q_right);
            else if (q_left > mid) return query(id * 2 + 2, mid + 1, right, q_left, q_right);
            else return Math.Max(query(id * 2 + 1, left, mid, q_left, q_right), query(id * 2 + 2, mid + 1, right, q_left, q_right));
        }
        public Seg(int[] nums)
        {
            arr = nums;
            len = arr.Length;
            seg = new int[len << 2];
            push(0, 0, len - 1);
        }
        public int Query(int left, int right) => query(0, 0, len - 1, left, right);
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //線段樹segment tree 找最大值，亦可找最大值、區間和...其他
            int[] nums = new int[] { 1, 5, 4, 3, 9, 7 };
            Seg seg = new Seg(nums);
            while (true)
            {
                int[] str = (Console.ReadLine() + "").Split(' ').Select(x => int.Parse(x)).ToArray();
                Console.WriteLine(seg.Query(str[0], str[1]));
            }
        }
    }
}