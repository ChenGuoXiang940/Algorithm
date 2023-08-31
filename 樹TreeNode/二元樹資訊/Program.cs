
namespace 二元樹資訊
{
    internal class Program
    {
        /*有序字典，對輸入的值直接做排序，相當於 C++ 的 priority_queue*/
        public static SortedDictionary<int, BT> dict = new SortedDictionary<int, BT>();
        public static string str = "";
        static void Main(string[] args)
        {
            /*知道父節點值、左節點值、右節點值，可以建立二元樹*/
            int[,] num = new int[6, 3] { { 0, 3, -1 }, { 1, -1, 5 }, { 2, -1, -1 }, { 3, 4, -1 }, { 4, 2, 1 }, { 5, -1, -1 } };
            for(int i = 0; i < num.GetLength(0); i++)
            {
                int root = num[i, 0], left = num[i, 1], right = num[i, 2];
                CheckandCreate(root);
                dict[root].left = left;
                dict[root].right = right;
                if (left != -1)
                {
                    CheckandCreate(left);
                    dict[left].parent = root;
                }
                if (right != -1)
                {
                    CheckandCreate(right);
                    dict[right].parent = root;
                }
            }
            Console.WriteLine("後序走訪:" + GetPost());
            Console.ReadKey();
        }
        /*如果值不存在，就建立新的加入*/
        public static void CheckandCreate(int val)
        {
            if (!dict.ContainsKey(val)) dict[val] = new BT();
        }
        public static void Post(int val)
        {
            if (val == -1) return;
            Post(dict[val].left);
            Post(dict[val].right);
            str += val.ToString() + ",";
        }
        public static string GetPost()
        {
            str = "";
            Post(0);//假設根為 0
            return str.TrimEnd(',');
        }
    }
    class BT
    {
        public int left, right, parent;
        public BT()
        {
            this.left = this.right = this.parent = -1;
        }
    }
}