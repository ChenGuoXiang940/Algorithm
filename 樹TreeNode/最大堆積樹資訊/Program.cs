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
            Console.WriteLine("後序走訪:" + heap.GetPost());
            Console.ReadKey();
        }
    }
    public class MaxHeap
    {
        private string s = "";
        private List<int> col;
        public MaxHeap() => col = new List<int>();
        private void insertRec(int index)
        {
            if (index == 0) return;
            int parent = (index - 1) >> 1;
            if (col[parent] < col[index])
            {
                col[parent] ^= col[index];
                col[index] ^= col[parent];
                col[parent] ^= col[index];
                insertRec(parent);
            }
        }
        private void post(int index)
        {
            if (index >= col.Count) return;
            post(index * 2 + 1);
            post(index * 2 + 2);
            s += $"{col[index]},";
        }
        public void Insert(int val)
        {
            col.Add(val);
            insertRec(col.Count - 1);
        }
        public string GetPost()
        {
            s = "";
            post(0);
            return s.TrimEnd(',');
        }
    }
}