using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using li = System.Collections.Generic.List<int>;
namespace _8puzzle
{
    public partial class Form1 : Form
    {
        public static TextBox[] t1, t2;
        public static List<li> moved = new List<li>() { new li() { 1, 3 }, new li() { 4, 2, 0 }, new li() { 5, 1 },
        new li(){6,4,0 },new li(){ 7,5,1,3},new li(){8,2,4 },new li(){7,3 },new li(){ 8,4,6},new li(){ 5,7} };
        public Form1()
        {
            InitializeComponent();
            t1 = new TextBox[] { tbb1, tbb2, tbb3, tbb4, tbb5, tbb6, tbb7, tbb8, tbb9 };
            t2 = new TextBox[] { tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9 };
        }
        public static Random rnd = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            Array.ForEach(t1, item => item.Text = i++ == 0 ? "" : $"{i - 1}");
            for(int j = 0; j < 10; j++)
            {
                swap(ref t1[rnd.Next(0, 9)], ref t1[rnd.Next(0, 9)]);
            }
        }
        public void enable(bool fg)
        {
            button1.Enabled = fg;
            button2.Enabled = fg;
            Array.ForEach(t1, item => item.Enabled = fg);
            Array.ForEach(t2, item => item.Enabled = fg);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            enable(false);
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            int start = 0, final = 0, power = 1, target = 0;
            for (int i = 8; i >= 0; i--)
            {
                if (t1[i].Text == "") target = 8 - i;
                else start += power * int.Parse(t1[i].Text);
                final += power * int.Parse(t2[i].Text == "" ? "0" : t2[i].Text);
                power *= 10;
            }
            HashSet<double> visited = new HashSet<double>();
            Queue<Data> queue = new Queue<Data>();
            queue.Enqueue(new Data(start, target));
            visited.Add(start);
            int len;
            Data result = null;
            while ((len = queue.Count) > 0)
            {
                for (int j = 0; j < len; j++)
                {
                    Data current = queue.Dequeue();
                    if (current.val == final)
                    {
                        result = current;
                        queue.Clear();
                        break;
                    }
                    foreach(var move in moved[current.index])
                    {
                        int val_new = swapDigits(current.val, current.index, move);
                        if (visited.Contains(val_new)) continue;
                        queue.Enqueue(new Data(val_new, move, current));
                        visited.Add(val_new);
                    }
                }
            }
            sw.Stop();
            if (result == null)
            {
                label3.Text = $"無解\r\n耗時:{Math.Round(sw.Elapsed.TotalSeconds, 3)}";
                enable(true);
                return;
            }
            Stack<Data> stack = new Stack<Data>();
            while (result != null)
            {
                stack.Push(result);
                result = result.father;
            }
            string record = (stack.Count - 1).ToString();
            label3.Text = $"{record}/{record}";
            Thread.Sleep(500);
            Application.DoEvents();
            while (true)
            {
                Thread.Sleep(500);
                Application.DoEvents();
                if (stack.Count == 0) break;
                double current = stack.Pop().val;
                for(int i = 0; i < 9; i++)
                {
                    t1[8 - i].Text = current % 10 < 0.99 ? "" : $"{(int)current % 10}";
                    current /= 10;
                }
                label3.Text = $"{stack.Count,-2}/{record}";
            }
            enable(true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void swap(ref TextBox a,ref TextBox b)
        {
            string tmp=a.Text; a.Text=b.Text; b.Text = tmp;
        }
        public static int[] power = new int[] { 1, (int)1E1, (int)1E2, (int)1E3, (int)1E4, (int)1E5, (int)1E6, (int)1E7, (int)1E8 };
        public int swapDigits(int num, int pos1, int pos2)
        {
            int m1 = power[pos1];
            int m2 = power[pos2];
            int digit1 = (num / m1) % 10;
            int digit2 = (num / m2) % 10;
            num -= (m1 * digit1 + m2 * digit2);
            return num + (m1 * digit2 + m2 * digit1);
        }
    }
    public class Data
    {
        public int val, index;
        public Data father;
        public Data(int val,int index, Data father = null)
        {
            this.val = val;
            this.index = index;
            this.father = father;
        }
    }
}
