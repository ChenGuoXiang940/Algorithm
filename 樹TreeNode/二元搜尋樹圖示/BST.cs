using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 二元搜尋樹圖示
{
    public class Node
    {
        public int val;
        public Point location;
        public Node left;
        public Node right;
        public Node(int val,Point point)
        {
            this.val = val;
            this.location = point;
            this.left = this.right = null;
        }
    }
    public class BST
    {
        public Node node;
        private Node InsertRec(int val,Node root,Point point,int deepth)
        {
            if (root == null) return new Node(val, point);
            else if (root.val > val) root.left = InsertRec(val, root.left, new Point(point.X - 100 + 5 * deepth, point.Y + 20), deepth + 1);
            else if (root.val < val) root.right = InsertRec(val, root.right, new Point(point.X + 100 - 5 * deepth, point.Y + 20), deepth + 1);
            return root;
        }
        public BST() { }
        public void Insert(int val)
        {
            if (node == null) node = new Node(val, new Point(250, 20));
            else node = InsertRec(val, node, node.location, 0);
        }
    }
}
