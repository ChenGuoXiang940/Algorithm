using System;

namespace 最小堆積樹資訊
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * 二元搜尋樹（BST）:
             * 建立目的:二元搜尋樹是用於維護排序性質。
             * 
             * 堆積樹 Heap（優先級佇列 Priority_Queue）:
             * 建立目的:用於結構性質而不是排序性質，走訪沒有意義。
             * 它允許我們在任何時候添加新的元素，並且能在O(1)的時間內找到（並刪除）最小的元素。
             */
            MinHeap heap = new MinHeap();
            int[] num = { 1, 6, 13, 16, 14, 8, 4, 5, 10 };
            foreach (int item in num)
            {
                heap.Insert(item);
            }
            int[] res = num.Select(x => heap.getMin()).ToArray();
            Console.WriteLine(string.Join("->", res));
            Console.ReadKey();
        }
    }
    class MinHeap
    {
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
                //從子節點回溯到父節點
                InsertRec(parentIndex);
            }
        }
        private void PercolateDown(int index)
        {
            int left = (index * 2) + 1;
            int right = (index * 2) + 2;
            int smallest = index;
            //最小堆的父節點必須小於左子節點
            if (heap.Count > left && heap[smallest] > heap[left]) smallest = left;
            //最小堆的父節點必須小於右子節點
            if (heap.Count > right && heap[smallest] > heap[right]) smallest = right;
            //如果父節點不是最小的，則交換
            if (smallest != index)
            {
                heap[smallest]^= heap[index];
                heap[index]^= heap[smallest];
                heap[smallest]^= heap[index];
                PercolateDown(smallest);
            }
        }
        public void Insert(int val)
        {
            heap.Add(val);
            InsertRec(heap.Count - 1);
        }
        public int getMin()
        {
            if (heap.Count == 0) throw new Exception("Heap is empty");
            int min_val = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            if (heap.Count > 1) PercolateDown(0);
            return min_val;
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
//索引對應位置:0、1、2、3、4、 5、6、 7、 8
//元素    位置:1、5、4、6、4、13、8、16、10
//後序:1->5->6->16->10->14->4->13->8
//輸出:1->4->5->6->8->10->13->14->16