namespace 二元搜尋樹資訊
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*輸入不重複的數可建立二元搜尋樹(Binary Search Tree，BST）*/
            int[] num = { 7, 4, 12, 1, 5, 8, 15 };
            int[] num1 = { 9, 6, 12, 2, 8, 11, 15, 1, 3, 7 };
            BST bst = new BST();
            foreach(int item in num1)
            {
                bst.insert(item);
            }
            Console.WriteLine(bst.getinfix());
            Console.ReadKey();
        }
    }
    class Node
    {
        public int val { get; }         //只可讀屬性，用於儲存節點的值
        public Node? left { get; set; } //可讀寫屬性，用於儲存左節點(?可能為空)
        public Node? right { get; set; }//可讀寫屬性，用於儲存右節點(?可能為空)
        public Node(int _val, Node? _left = null, Node? _right = null)
        {
            val = _val;      //初始化節點的值
            left ??= _left;  //初始化左節點，如果未提供則為空
            right ??= _right;//初始化右節點，如果未提供則為空
        }
    }
    class BST
    {
        private Node? node;
        private string? s;
        //此處遞迴可以建立搜尋二元樹
        private Node? insertrec(Node? root,int val)
        {
            if (root == null) return new Node(val);
            /*左子樹的鍵值均要小於樹根的鍵值*/
            else if (val < root.val) root.left = insertrec(root.left, val);
            /*右子樹的鍵值均要大於樹根的鍵值*/
            else if (val > root.val) root.right = insertrec(root.right, val);
            return root;
        }
        //此處可以實現插入資料、中序走訪，也可額外新增其他操作，如:搜尋、刪除等等
        private void infix(Node? root)
        {
            if(root == null) return;
            infix(root.left);
            s += root.val.ToString() + ",";
            infix(root.right);
        }
        public BST() { }
        public void insert(int val)=> node = insertrec(node, val);
        public string getinfix()
        {
            s = "";
            infix(node);
            return s.TrimEnd(',');
        }
    }
}