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
        public static Pen pen = new Pen(Color.Linen, 3);
        public static Font font = new Font("Default", 9);
        public static Stopwatch sw = Stopwatch.StartNew();
        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(500, 500);
            g = Graphics.FromImage(bitmap);
            g.Clear(Color.Black);
            pictureBox1.Image = bitmap;
        }
        public static List<Point> col = new List<Point>();
        private void button1_Click(object sender, EventArgs e)
        {
            col.Clear();
            for(int i = 0; i < 25; i++)
            {
                int x = Data.rnd.Next(15, 485);
                int y = Data.rnd.Next(15, 485);
                Point point = new Point(x, y);
                bool fg = true;
                foreach (Point it in col)
                {
                    if (Data.GetDistance(it, point) < 50)
                    {
                        fg = false;
                        break;
                    }
                }
                if (fg) col.Add(point);
                else i--;
            }
            Reset();
        }
        public void Reset()
        {
            g.Clear(Color.Black);
            for (int i = 0; i < 25; i++)
            {
                g.FillEllipse(Brushes.YellowGreen, col[i].X - 5, col[i].Y - 5, 10, 10);
            }
            pictureBox1.Image = bitmap;
        }
        public static int[] seq;
        public static int[] seq_f;
        private void button2_Click(object sender, EventArgs e)
        {
            sw.Restart();
            //退火蟻演算法解決旅行商問題(TSP，Travelling Salesman Problem)
            //初始化
            seq = new int[25];
            seq_f = new int[25];
            double tempterature = 10000;//初始溫度
            double result = 1E9;        //最短路徑長度
            double new_energy = 1, old_energy = 0;
            double[,] distance = new double[25, 25];
            //建立圖
            for (int i = 0; i < 25; i++)
            {
                for(int j = 0; j < 25; j++)
                {
                    //自己到自己不考慮距離(為零)
                    distance[i, j] = i == j ? 0 : Data.GetDistance(col[i], col[j]);
                }
            }
            for(int i = 0; i < 25; i++)
            {
                //紀錄順序 0~24
                seq[i] = seq_f[i] = i;
            }
            //使用退火蟻演算法進行迭代，直到溫度足夠低或能量變化足夠小
            while (tempterature > 1E-9 && Math.Abs(new_energy - old_energy) > 1E-9)
            {
                int iterate = 100;//設定迭帶次數
                int[] seq_ff = new int[25];//存儲產生的序列
                while (iterate-- >= 0 && Math.Abs(new_energy - old_energy) > 1E-9)
                {
                    //生成新的序列
                    Data.generate1(ref seq_ff);
                    //計算新與舊各自的能量
                    new_energy = Data.count_energy(ref seq_ff);
                    old_energy = Data.count_energy(ref seq_f);
                    //Metroplis-Hastings 演算法 (Metropolis-Hastings algorithm)
                    //從複雜的概率分佈中抽取樣本
                    if (Data.metro(old_energy, new_energy, tempterature))
                    {
                        //如果接受，將新生成的序列複製到原序列
                        seq_f = seq_ff.ToArray();
                    }
                }              
                new_energy = Data.count_energy(ref seq_f);
                old_energy = result;
                if (Data.metro(old_energy, new_energy, tempterature))
                {
                    seq = seq_f.ToArray();
                    //降低溫度，以便更容易接受新的序列，但不會太快，以免陷入局部最小值
                    tempterature *= 0.998;
                }
                else
                {
                    //稍微降低溫度
                    tempterature *= 0.999;
                }
                result = Data.count_energy(ref seq);
            }
            Reset();
            g.DrawString("25", font, Brushes.BlueViolet, col[seq[0]]);
            g.DrawLine(pen, col[seq[0]], col[seq[24]]);
            for (int i = 1; i < 25; i++)
            {
                g.DrawLine(pen, col[seq[i]], col[seq[i - 1]]);
                g.DrawString($"{i}", font, Brushes.BlueViolet, col[seq[i]]);
            }
            pictureBox1.Image = bitmap;
            sw.Stop();
            MessageBox.Show($"時間:{Math.Round(sw.Elapsed.TotalSeconds, 3)}", "資訊", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
