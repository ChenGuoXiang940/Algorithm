namespace 最大堆積樹資訊
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MaxHeap heap = new MaxHeap();
            int[] num = { 1, 6, 13, 16, 14, 8, 4, 5, 10 };
            foreach (int item in num)
            {
                heap.Insert(item);
            }
            int[] res = num.Select(x => heap.getMax()).ToArray();
            Console.WriteLine(string.Join("->", res));
            Console.ReadKey();
        }
    }
    public class MaxHeap
    {
        private List<int> col;
        public MaxHeap() => col = new List<int>();
        private void InsertRec(int index)
        {
            if (index == 0) return;
            int parent = (index - 1) / 2;
            if (col[parent] < col[index])
            {
                col[parent] ^= col[index];
                col[index] ^= col[parent];
                col[parent] ^= col[index];
                InsertRec(parent);
            }
        }
        private void PercolateDown(int index)
        {
            int left = (index * 2) + 1;
            int right = (index * 2) + 2;
            int largest = index;
            if (col.Count > left && col[left] > col[largest]) largest = left;
            if (col.Count > right && col[right] > col[largest]) largest = right;
            if (col[largest] != col[index])
            {
                col[largest]^= col[index];
                col[index]^= col[largest];
                col[largest]^= col[index];
                PercolateDown(largest);
            }
        }
        public void Insert(int val)
        {
            col.Add(val);
            InsertRec(col.Count - 1);
        }
        public int getMax()
        {
            if (col.Count == 0) throw new Exception("heap is empty");
            int max_val = col[0];
            col[0] = col[col.Count - 1];
            col.RemoveAt(col.Count - 1);
            if (col.Count > 1) PercolateDown(0);
            return max_val;
        }
    }
}