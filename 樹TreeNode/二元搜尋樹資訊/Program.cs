namespace 二元搜尋樹資訊
{
    internal class Program
    {
        /*建立二元搜尋樹(Binary Search Tree，BST）*/
        static void Main(string[] args)
        {
            int[] num = { 7, 4, 12, 1, 5, 8, 15 };
            BST bst = new BST();
            foreach(int item in num)
            {
                bst.Insert(item);
            }
            Console.WriteLine(bst.GetInfix());
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
        //此處遞迴可以建立二元搜尋樹
        private Node? InsertRec(Node? root,int val)
        {
            if (root == null) return new Node(val);
            /*左子樹的鍵值均要小於樹根的鍵值*/
            else if (val < root.val) root.left = InsertRec(root.left, val);
            /*右子樹的鍵值均要大於樹根的鍵值*/
            else if (val > root.val) root.right = InsertRec(root.right, val);
            return root;
        }
        //此處可以實現插入資料、中序走訪，也可額外新增其他操作，如:搜尋、刪除等等
        private void Infix(Node? root)
        {
            if(root == null) return;
            Infix(root.left);
            s += root.val.ToString() + ",";
            Infix(root.right);
        }
        public BST() { }
        public void Insert(int val)=> node = InsertRec(node, val);
        public string GetInfix()
        {
            s = "";
            Infix(node);
            return s.TrimEnd(',');
        }
    }
}