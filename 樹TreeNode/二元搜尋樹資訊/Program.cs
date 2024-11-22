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
        public int val;
        public Node? left, right;
        public Node(int val) => this.val = val;
    }
    class BST
    {
        private Node? node;
        private string s = "";
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
        //此處可以實現插入資料、中序走訪，也可額外新增其他操作，如:搜尋、刪除、交換、計算深度...等等
        private void Infix(Node? root)
        {
            if(root == null) return;
            Infix(root.left);
            s += root.val.ToString() + ",";
            Infix(root.right);
        }
        public BST() { }
        public void Insert(int val) => node = InsertRec(node, val);
        public string GetInfix()
        {
            s = "";
            Infix(node);
            return s.TrimEnd(',');
        }
    }
}