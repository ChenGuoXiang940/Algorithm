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
             * 最小堆積樹Heap(優先級佇列 Priority Queue):
             * 建立目的:用於結構性質而不是排序性質(走訪沒有意義，範例僅用於展示)
             */
            MinHeap heap = new MinHeap();
            int[] num = { 1, 6, 13, 16, 14, 8, 4, 5, 10 };
            foreach (int item in num)
            {
                heap.Insert(item);
            }
            Console.WriteLine("後序走訪:" + heap.GetPost());
            Console.ReadKey();
        }
    }
    class MinHeap
    {
        private string? s;
        private List<int> heap; 
        public MinHeap() => heap = new List<int>();
        private void InsertRec(int index)
        {
            if (index == 0) return;
            int parentIndex = (index - 1) / 2;
            //最小堆的父節點必須小於子節點
            //當前元素索引 index，其左節點 index*2+1，其右節點 index*2+2
            if (heap[parentIndex] > heap[index])
            {
                //位運算做互斥或交換
                heap[parentIndex] ^= heap[index];
                heap[index] ^= heap[parentIndex];
                heap[parentIndex] ^= heap[index];
                InsertRec(parentIndex);
            }
        }
        private void Post(int index)
        {
            if (index >= heap.Count) return;
            s += heap[index].ToString() + ",";
            Post(index * 2 + 1);
            Post(index * 2 + 2);
        }
        public void Insert(int val)
        {
            heap.Add(val);
            InsertRec(heap.Count - 1);
        }
        public string GetPost()
        {
            s = "";
            Post(0);
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
//索引:0、1、2、3、4、 5、6、 7、 8
//元素:1、5、4、6、4、13、8、16、10
//
//後序:1->5->6->16->10->14->4->13->8