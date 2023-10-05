namespace 二元搜尋樹資訊2
{
    internal class Program
    {
        /*以堆積(heap)建立二元搜尋樹(Binary Search Tree，BST）*/
        public static int[] heap = new int[0];
        public static string s = "";
        public static void infix(int id)
        {
            if (id << 1 > heap.Length || heap[id] == -1) return;//剪枝
            infix(id << 1);
            s += $"{heap[id]},";
            infix((id << 1) | 1);
        }
        public static int insertRec(int id,int val)
        {
            if (heap[id] == -1) return val;
            /*左節點要小於根節點*/
            if (val < heap[id]) heap[id << 1] = insertRec(id << 1, val);
            /*右節點要大於根節點*/
            if (val > heap[id]) heap[(id << 1) | 1] = insertRec((id << 1) | 1, val);
            return heap[id];
        }
        public static void insert(int val) => heap[1] = insertRec(1, val);
        public static string getInfix()
        {
            s = "";
            infix(1);
            return s.TrimEnd(',');
        }
        static void Main(string[] args)
        {
            int[] num = { 7, 4, 12, 1, 5, 8, 15 };
            heap = new int[num.Length << 2].Select(item => -1).ToArray();
            foreach(int item in num)
            {
                insert(item);
            }
            Console.WriteLine(getInfix());
            Console.ReadKey();
        }
    }
    public class Node
    {
        public int val;
        public Node? left, right;
        public Node(int val)
        {
            this.val = val;
        }
    }
}