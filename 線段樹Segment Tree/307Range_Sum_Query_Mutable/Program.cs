using System;

namespace _307Range_Sum_Query_Mutable
{
    public class SegmentTree
    {
        private int len;
        private int[] seg;
        private void buildTree(ref int[] arr,int id,int left,int right)
        {
            if (left == right) // 當前區間為單一元素
            {
                seg[id] = arr[left];
                return;
            }
            int mid = (left + right) >> 1;
            buildTree(ref arr, id << 1, left, mid);// 正確的區間分割應該包含中點本身 right = mid
            buildTree(ref arr, (id << 1) + 1, mid + 1, right);
            seg[id] = seg[id << 1] + seg[(id << 1) + 1];
        }
        // 根據目標索引位置遞歸地更新樹的節點
        private void update(int id,int left,int right,int pos,int val)
        {
            if (left == right)
            {
                seg[id] = val;
                return;
            }
            int mid = (left + right) >> 1;
            //  pos 以 mid 為基準進入左/右半邊(二分剪枝)
            if (pos <= mid) update(id << 1, left, mid, pos, val);
            else update((id << 1) + 1, mid + 1, right, pos, val);
            //  更新seg
            seg[id] = seg[id << 1] + seg[(id << 1) + 1];
        }
        private int query(int id,int left,int right,int q_left,int q_right)
        {
            if (left > q_right || right < q_left) return 0;
            if (q_left <= left && right <= q_right) return seg[id];
            int mid = (left + right) >> 1;
            return query(id << 1, left, mid, q_left, q_right) + 
                query((id << 1) + 1, mid + 1, right, q_left, q_right);
        }
        public SegmentTree(int[] nums)
        {
            len = nums.Length;
            seg = new int[len << 2];
            buildTree(ref nums, 1, 0, len - 1);
        }
        // 通過 update 方法來更新線段樹
        public void Update(int index, int val)
        {
            update(1, 0, len - 1, index, val);
        }
        public int SumRange(int left, int right) => query(1, 0, len - 1, left, right);
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 3, 5, 7, 9 };
            SegmentTree obj = new SegmentTree(nums);
            Console.WriteLine(obj.SumRange(0, 2)); // return 1 + 3 + 5 = 9
            obj.Update(1, 2);   // nums = [1, 2, 5, 7, 9]
            Console.WriteLine(obj.SumRange(0, 2)); // return 1 + 2 + 5 = 8
        }
    }
}