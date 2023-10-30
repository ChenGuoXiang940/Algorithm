namespace 區間最大值
{
    class Seg
    {
        private int len;
        private int[] seg, arr;
        private void push(int id,int left,int right)
        {
            if (left == right) { seg[id] = arr[left]; return; }
            int mid = (left + right) >> 1;
            push(id << 1, left, mid);
            push((id << 1) | 1, mid + 1, right);
            seg[id] = Math.Max(seg[id << 1], seg[(id << 1) | 1]);
        }
        private int query(int id,int left,int right,int q_left,int q_right)
        {
            if (left > q_right || right < q_left) return 0;
            if (q_left <= left && right <= q_right) return seg[id];
            int mid = (left + right) >> 1;
            if (q_right <= mid) return query(id << 1, left, mid, q_left, q_right);
            else if (q_left > mid) return query((id << 1) | 1, mid + 1, right, q_left, q_right);
            else return Math.Max(query(id << 1, left, mid, q_left, q_right), query((id << 1) | 1, mid + 1, right, q_left, q_right));
        }
        public Seg(int[] nums)
        {
            arr = nums;
            len = arr.Length;
            seg = new int[len << 2];
            push(1, 0, len - 1);
        }
        public int Query(int left, int right) => query(1, 0, len - 1, left, right);
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //線段樹segment tree 找最大值，亦可找最小值、求區間和、處理覆蓋面積...其他
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