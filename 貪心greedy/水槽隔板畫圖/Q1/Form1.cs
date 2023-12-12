using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q1
{
    public partial class Form1 : Form
    {
        public static Bitmap bitmap = new Bitmap(500, 250);
        public static Graphics g;
        public static Pen pen = new Pen(Color.Black, 3);
        public static Font font = new Font("Default", 9);
        public static Point final;
        public static Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            g = Graphics.FromImage(bitmap);
            
        }
        public void Reset()
        {
            g.Clear(Color.White);
            g.DrawRectangle(pen, 25, 25, 450, 200);
            for(int i = 0; i < 10; i++)
            {
                g.DrawString($"{i}", font, Brushes.Black, 10, 215 - 20 * i);
                g.DrawLine(pen, 25, 225 - 20 * i, 30, 225 - 20 * i);
                g.DrawString($"{i + 1}", font, Brushes.Black, 50 + 40 * i, 230);           
            }
            pictureBox1.Image = bitmap;
        }
        public static int water(int[]hs,int c)
        {
            int total = Int32.MaxValue;
            int record;
            for (int i = 0; i < hs.Length; i++)
            {
                record = 0;
                for (int j = i + 1; j < hs.Length; j++)
                {
                    if (record < hs[j])
                    {
                        int a = Math.Min(hs[i], hs[j]) * (j - i);
                        if (a == c)
                        {
                            final = new Point(i, j);
                            return c;
                        }
                        else if (total > a && a > c)
                        {
                            final = new Point(i, j);
                            total = a;
                        }
                    }
                    record = Math.Max(record, hs[j]);
                    if (hs[i] <= record) break;
                }
            }
            if (total == Int32.MaxValue) return -1;
            return total;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Reset();
            int[] hs = textBox1.Text.Split(' ').Select(item => int.Parse(item)).ToArray();
            int c = int.Parse(textBox3.Text);
            int ans = water(hs, c);
            if (ans != -1)
            {
                textBox2.Text = $"{ans}";
                g.FillRectangle(Brushes.LightBlue, 50 + 40 * final.X, 225 - 20 * Math.Min(hs[final.X], hs[final.Y]), 40 * (final.Y - final.X), 20 * Math.Min(hs[final.X], hs[final.Y]));
                for(int i = 0; i < hs.Length; i++)
                {
                    g.FillRectangle(Brushes.Red, 50 + 40 * i, 225 - 20 * hs[i], 5, 20 * hs[i]);
                }
                g.FillRectangle(Brushes.DarkBlue, 50 + 40 * final.X, 225 - 20 * hs[final.X], 5, 20 * hs[final.X]);
                g.FillRectangle(Brushes.DarkBlue, 50 + 40 * final.Y, 225 - 20 * hs[final.Y], 5, 20 * hs[final.Y]);
            }
            else
            {
                for (int i = 0; i < hs.Length; i++)
                {
                    g.FillRectangle(Brushes.Red, 50 + 40 * i, 225 - 20 * hs[i], 5, 20 * hs[i]);
                }
                MessageBox.Show("無解","Hint");
                textBox2.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Join(" ", new int[10].Select(x => rnd.Next(1, 10)));
            textBox3.Text = $"{rnd.Next(5, 20)}";
            button1_Click(sender, e);
        }
    }
}
