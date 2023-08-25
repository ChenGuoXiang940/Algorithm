using System;

namespace 最小堆積樹資訊
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * 二元搜尋樹(BST):
             * 建立目的:二元搜尋樹是用於維護排序性質。
             * 
             * 最小堆積樹Heap(優先級佇列Priority Queue):
             * 建立目的:用於結構性質而不是排序性質(走訪沒有意義)
             */
            MinHeap heap = new MinHeap();
            int[] num = { 1, 6, 13, 16, 14, 8, 4, 5, 10 };
            foreach (int item in num)
            {
                heap.insert(item);
            }
            Console.WriteLine(heap.getpost());
            Console.ReadKey();
        }
    }
    class MinHeap
    {
        private string? s;
        private List<int> heap;
        public MinHeap() => heap = new List<int>();
        private void insertrec(int index)
        {
            if (index == 0) return;
            int parentIndex = (index - 1) / 2;
            if (heap[parentIndex] > heap[index])
            {
                int tmp = heap[parentIndex];
                heap[parentIndex] = heap[index];
                heap[index] = tmp;
                insertrec(parentIndex);
            }
        }
        private void post(int index)
        {
            if (index >= heap.Count) return;
            s += heap[index].ToString() + ",";
            post(index * 2 + 1);
            post(index * 2 + 2);
        }
        public void insert(int val)
        {
            heap.Add(val);
            insertrec(heap.Count - 1);
        }
        public string getpost()
        {
            s = "";
            post(0);
            return s.TrimEnd(',');
        }
    }
}
//               1
//            /    \
//           5      4
//          /  \    / \
//         6   14  13  8
//        / \ 
//      16  10