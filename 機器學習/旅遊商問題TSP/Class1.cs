using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using f = 旅遊商問題TSP.Form1;
namespace 旅遊商問題TSP
{
    internal class Data
    {
        public static Random rnd = new Random();
        public static int rd() => rnd.Next(0, 25);
        public static Func<Point, Point, double> GetDistance = (Point p1, Point p2) => Math.Abs(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        public static double count_energy(ref int[] conf)
        {
            double temp = 0;
            for (int i = 1; i < 25; ++i)
            {
                temp += GetDistance(f.col[conf[i]], f.col[conf[i - 1]]);
            }
            temp += GetDistance(f.col[conf[0]], f.col[conf[25 - 1]]);
            return temp;
        }
        public static bool metro(double f1, double f2, double t)
        {
            if (f2 < f1) return true;
            double p = Math.Exp(-(f2 - f1) / t);
            double bignum = 1E9;
            if (rnd.Next(0, 36768) % bignum < p * bignum) return true;
            return false;
        }
        public static void generate(ref int[] s)//隨機產生一組新解
        {
            bool[] vist = new bool[25];
            for (int i = 0; i < 25; ++i)
            {
                s[i] = rd();
                while (vist[s[i]])
                {
                    s[i] = rd();
                }
                vist[s[i]] = true;
            }
        }
        public static void generate1(ref int[] s)//隨機交換序列中的一組城市順序
        {
            int ti = rd();
            int tj = ti;
            while (ti == tj)
            {
                tj = rd();
            }
            for (int i = 0; i < 25; i++)
            {
                s[i] = f.seq[i];
            }
            swap(ref s[ti],ref s[tj]);
        }
        public static void generate2(ref int[] s)//隨機交換序列中的兩組城市順序
        {
            int ti = rd();
            int tj = ti;
            int tk = ti;
            while (ti == tj)
            {
                tj = rd();
            }
            while (ti == tj || tj == tk || ti == tk)
            {
                tk = rd();
            }
            for (int i = 0; i < 25; ++i)
            {
                s[i] = f.seq[i];
            }  
            swap(ref s[ti], ref s[tj]);
            swap(ref s[tk], ref s[tj]);
        }
        public static void generate3(ref int[] s)//隨機選序列中的三個城市互相交換順序
        {
            int ti = rd();
            int tj = ti;
            int tm = rd();
            int tn = ti;
            while (ti == tj)
            {
                tj = rd();
            }
            while (tm == tn)
            {
                tn = rd();
            }
            for (int i = 0; i < 25; ++i)
            {
                s[i] = f.seq[i];
            }
            swap(ref s[ti], ref s[tj]);
            swap(ref s[tm], ref s[tn]);
        }
        public static void generate0(ref int[] s)//以上三種交換方式等概率選擇
        {
            switch (f.rnd.Next(0, 3))
            {
                case 0:
                    generate1(ref s);
                    break;
                case 1:
                    generate2(ref s);
                    break;
                case 2:
                    generate3(ref s);
                    break;
            }
        }
        public static void swap<T>(ref T a, ref T b)
        {
            T tmp = a; a = b; b = tmp;
        }
    }
}
