using System.Data;

namespace 二元樹資訊
{
    internal class Program
    {
        /*有序字典，對輸入的int直接做排序，相當於C++的priority_queue*/
        public static SortedDictionary<int, BT> dict = new SortedDictionary<int, BT>();
        /*後序走訪*/
        public static string str = "";
        public static void post(int val)
        {
            if (val == -1) return;
            post(dict[val].left);
            post(dict[val].right);
            str += val.ToString() + ",";
        }
        /*如果值不存在dict就建立新的BT加入*/
        public static void checkandcreate(int val)
        {
            if (!dict.ContainsKey(val)) dict[val] = new BT();
        }
        static void Main(string[] args)
        {
            /*知道左節點值、右節點值、父節點值，可以建立二元樹*/
            string s;
            while (!string.IsNullOrEmpty(s = Console.ReadLine() + ""))
            {
                int[] arr = s.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int root = arr[0], left = arr[1], right = arr[2];
                checkandcreate(root);
                dict[root].left = left;
                dict[root].right = right;
                if (left != -1)
                {
                    checkandcreate(left);
                    dict[left].parent = root;
                }
                if (right != -1)
                {
                    checkandcreate(right);
                    dict[right].parent = root;
                }
            }
            post(0);
            Console.WriteLine(str.TrimEnd(','));
            Console.ReadKey();
            /*
0 3 -1
1 -1 5
2 -1 -1
3 4 -1
4 2 1
5 -1 -1
             */
        }
    }
    class BT
    {
        public int left { get; set; }  //可讀寫屬性，用於儲存左節點
        public int right { get; set; } //可讀寫屬性，用於儲存右節點
        public int parent { get; set; }//可讀寫屬性，用於儲存父節點
        public BT()
        {
            this.left = -1;  //初始化左節點
            this.right = -1; //初始化右節點
            this.parent = -1;//初始化父節點
        }
    }
}