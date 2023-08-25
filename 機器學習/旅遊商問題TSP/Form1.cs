using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection.Emit;

namespace 旅遊商問題TSP
{
    public partial class Form1 : Form
    {
        public static Bitmap bitmap;
        public static Graphics g;
        public static Pen pen = new Pen(Color.Blue, 3);
        public static Font font = new Font("Default", 9);
        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(500, 500);
            g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            pictureBox1.Image = bitmap;
        }
        public static Random rnd = new Random();
        public static List<Point> col = new List<Point>();
        public static Func<Point, Point, double> GetDistance = (Point p1, Point p2) => Math.Abs(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "時間:";
            label2.Text = "最短路徑長度:";
            col.Clear();
            for(int i = 0; i < 25; i++)
            {
                int x = rnd.Next(10, 490);
                int y = rnd.Next(10, 490);
                if (!col.Contains(new Point(x, y))) col.Add(new Point(x, y));
            }
            reset();
        }
        public void reset()
        {
            g.Clear(Color.White);
            for (int i = 0; i < 25; i++)
            {
                g.FillEllipse(Brushes.Blue, col[i].X - 5, col[i].Y - 5, 10, 10);
            }
            pictureBox1.Image = bitmap;
        }
        public static int[] seq;  //最短路徑
        public static int[] seq_f;
        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            seq = new int[25];
            seq_f = new int[25];
            double tempterature = 10000;//初始溫度
            double result = 1E9;        //最短路徑長度
            double new_energy = 1, old_energy = 0;
            double[,] distance = new double[25, 25];
            for (int i = 0; i < 25; i++)
            {
                for(int j = 0; j < 25; j++)
                {
                    distance[i, j] = i == j ? 0 : GetDistance(col[i], col[j]);
                }
            }
            for(int i = 0; i < 25; i++)
            {
                seq[i] = seq_f[i] = i;
            }
            while (tempterature > 1E-9 && Math.Abs(new_energy - old_energy) > 1E-9)
            {
                int iterate = 100;
                int[] seq_ff = new int[25];
                while (iterate-- >= 0 && Math.Abs(new_energy - old_energy) > 1E-9)
                {
                    Data.generate1(ref seq_ff);
                    new_energy = Data.count_energy(ref seq_ff);
                    old_energy = Data.count_energy(ref seq_f);
                    if (Data.metro(old_energy, new_energy, tempterature))
                    {
                        for (int i = 0; i < 25;)
                        {
                            seq_f[i] = seq_ff[i++];
                        }
                    }
                }
                new_energy = Data.count_energy(ref seq_f);
                old_energy = result;
                if (Data.metro(old_energy, new_energy, tempterature))
                {
                    for (int i = 0; i < 25;)
                    {
                        seq[i] = seq_f[i++];
                    }
                    tempterature *= 0.998;
                }
                else
                {
                    tempterature *= 0.999;
                }
                result = Data.count_energy(ref seq);
            }
            reset();
            g.DrawString("25", font, Brushes.Black, col[seq[0]]);
            g.DrawLine(pen, col[seq[0]], col[seq[24]]);
            for (int i = 1; i < 25; i++)
            {
                g.DrawLine(pen, col[seq[i]], col[seq[i - 1]]);
                g.DrawString($"{i}", font, Brushes.Black, col[seq[i]]);
            }
            pictureBox1.Image = bitmap;
            sw.Stop();
            label1.Text = $"時間:{Math.Round(sw.Elapsed.TotalSeconds, 3)}";
            label2.Text = $"最短路徑長度:{result}";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
