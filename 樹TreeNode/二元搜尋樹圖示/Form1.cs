using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace 二元搜尋樹圖示
{
    public partial class Form1 : Form
    {
        public static Bitmap bitmap;
        public static Graphics g;
        public static BST bst;
        public static Random rnd = new Random();
        public static Font font = new Font("Consolas", 12);
        public static Pen Arrow = new Pen(Brushes.BlueViolet, 5);
        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(500, 500);
            g = Graphics.FromImage(bitmap);
            bst = new BST();
            reset();
            Arrow.StartCap = LineCap.ArrowAnchor;
        }
        public void reset()
        {
            richTextBox1.Text = "";//8 3 10 1 6 14  4 7 13
            g.Clear(Color.White);
            pictureBox1.Image = bitmap;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (Form2 f = new Form2())
            {
                f.DataInputCompleted += F_DataInputCompleted;
                DialogResult result = f.ShowDialog();
                if (result == DialogResult.OK)
                {
                    //Nothing...
                }
            }
        }
        private void F_DataInputCompleted(object sender, EventArgs e)
        {
            foreach (int item in Form2.col)
            {
                bst.Insert(item);
            }
            reset();
            richTextBox1.Text = GetPost();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bst = new BST();
            reset();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private string result;
        public string GetPost()
        {
            result = "";
            PostDraw(bst.node);
            Post(bst.node);
            pictureBox1.Image = bitmap;
            return result.TrimEnd(',');
        }
        private void Post(Node root)
        {
            if (root == null) return;
            Post(root.left);
            Post(root.right);
            result += $"{root.val},";
            g.DrawString($"{root.val}", font, new SolidBrush(Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256))), root.location);
        }
        private void PostDraw(Node root)
        {
            if (root.left != null)
            {
                g.DrawLine(Arrow, root.left.location, root.location);
                PostDraw(root.left);
            }
            if (root.right != null)
            {
                g.DrawLine(Arrow, root.right.location, root.location);
                PostDraw(root.right);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reset();
            button1.Enabled = button2.Enabled = button3.Enabled = false;
            HashSet<int> hash = new HashSet<int>();
            while (hash.Count != 25)
            {
                hash.Add(rnd.Next(0, 100));
            }
            foreach(int item in hash)
            {
                bst.Insert(item);
                richTextBox1.Text = GetPost();
                Thread.Sleep(500);
                Application.DoEvents();
            }
            button1.Enabled = button2.Enabled = button3.Enabled = true;
        }
    }
}
