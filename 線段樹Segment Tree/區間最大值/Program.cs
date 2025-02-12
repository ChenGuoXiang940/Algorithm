﻿namespace 區間最大值
{
    class SegmentTree
    {
        private int len;
        private int[] seg;
        private void buildTree(ref int[]arr,int id,int left,int right)
        {
            if (left == right)
            {
                Console.WriteLine($"設seg[{id}]={arr[left]},{left}-{right}");
                seg[id] = arr[left]; 
                return;
            }
            int mid = (left + right) >> 1;
            Console.WriteLine($"進入左子樹id={id << 1}，{left}-{mid}");
            buildTree(ref arr, id << 1, left, mid);
            Console.WriteLine($"進入右子樹id={(id << 1) | 1}，{mid+1}-{right}");
            buildTree(ref arr, (id << 1) | 1, mid + 1, right);
            Console.WriteLine($"設seg[{id}]=Max({seg[id << 1]}, {seg[(id << 1) | 1]}),{id << 1}-{(id << 1) | 1}");
            seg[id] = Math.Max(seg[id << 1], seg[(id << 1) | 1]);
        }
        private int query(int id,int left,int right,int q_left,int q_right)
        {
            if (left > q_right || right < q_left) return -1;    //  如果查詢區間與當前節點區間無交集
            if (q_left <= left && right <= q_right) return seg[id]; //   如果當前節點區間完全包含在查詢區間內
            int mid = (left + right) >> 1;
            //  否則，根據查詢區間的位置，遞歸查詢左子樹或右子樹，或者同時查詢左右子樹並返回較大的值。
            if (q_right <= mid) return query(id << 1, left, mid, q_left, q_right);
            else if (q_left > mid) return query((id << 1) | 1, mid + 1, right, q_left, q_right);
            else return Math.Max(query(id << 1, left, mid, q_left, q_right), query((id << 1) | 1, mid + 1, right, q_left, q_right));
        }
        public SegmentTree(int[] nums)
        {
            len = nums.Length;
            seg = new int[len << 2];
            buildTree(ref nums, 1, 0, len - 1);
            Console.WriteLine("segment tree:" + string.Join(" ", seg));
        }
        public int Query(int left, int right)
        {
            if (left < 0 || right < 0 || left >= len || right >= len) return -1;
            return query(1, 0, len - 1, left, right);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //線段樹找最大值，亦可找最小值、求區間和、處理覆蓋面積...其他
            int[] nums = new int[] { 1, 5, 4, 3, 9, 7 };
            SegmentTree seg = new SegmentTree(nums);
            while (true)
            {
                int[] str = (Console.ReadLine() + "").Split(' ').Select(x => int.Parse(x)).ToArray();
                //輸入 0 2 得 1,5,4 其中 5 最大則輸出
                Console.WriteLine(seg.Query(str[0], str[1]));
            }
        }
    }
}