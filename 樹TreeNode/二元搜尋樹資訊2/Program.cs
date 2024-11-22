using System;

namespace 二元搜尋樹資訊2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] num = { 7, 4, 12, 1, 5, 8, 15 };
            BST bst = new BST(num.Length);
            foreach(int item in num)
            {
                bst.insert(item);
            }
            Console.WriteLine(bst.getInfix());
            Console.ReadKey();
        }
    }
    /*以陣列建立二元搜尋樹(Binary Search Tree，BST）*/
    public class BST
    {
        private int[] heap;
        private string s = "";
        public BST(int len)
        {
            this.heap = new int[len << 2].Select(item => -1).ToArray();
        }
        private void infix(int id)
        {
            if (id << 1 > heap.Length || heap[id] == -1) return;//剪枝
            infix(id << 1);
            s += $"{heap[id]},";
            infix((id << 1) | 1);
        }
        private int insertRec(int id, int val)
        {
            if (heap[id] == -1) return val;
            /*左節點要小於根節點*/
            if (val < heap[id]) heap[id << 1] = insertRec(id << 1, val);
            /*右節點要大於根節點*/
            if (val > heap[id]) heap[(id << 1) | 1] = insertRec((id << 1) | 1, val);
            return heap[id];
        }
        public void insert(int val) => heap[1] = insertRec(1, val);
        public string getInfix()
        {
            s = "";
            infix(1);
            return s.TrimEnd(',');
        }
    }
}