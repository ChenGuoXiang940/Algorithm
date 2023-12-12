using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 堆疊
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static Stack stack = new Stack();
        public static Random rnd = new Random();
        public static string getStr() => string.Join("", new string[3].Select(x => (char)rnd.Next(65, 91)));
        private void button1_Click(object sender, EventArgs e)
        {
            TextBox text = new TextBox() { Name = $"textBox{stack.sign}", Text = getStr(), Location = new Point(stack.x, 10), Size = new Size(50, 10) };
            panel1.Controls.Add(text);
            stack.Push(text);
            textBox1.Text = $"message:新增{stack.Peek().Text}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!stack.isEmpty())
            {
                textBox1.Text = $"message:移除{stack.Peek().Text}";
                panel1.Controls.Remove(stack.Pop());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = $"message:清除";
            panel1.Controls.Clear();
            stack.Clear();
        }
    }
    public class Stack
    {
        public Stack() => list = new List<TextBox>();
        private List<TextBox> list;
        private int aim = 0;
        public int sign = 1, x = 30;
        public void Push(TextBox s)
        {
            if (list.Count == aim)
            {
                list.Add(new TextBox());
            }
            list[aim++] = s;
            x += 60;
            sign++;
        }
        public TextBox Pop()
        {
            x -= 60;
            return list[--aim];
        }
        public TextBox Peek() => list[aim - 1];
        public bool isEmpty() => aim == 0;
        public void Clear()
        {
            list.Clear();
            aim = 0;
            x = 30;
        }
    }
}
