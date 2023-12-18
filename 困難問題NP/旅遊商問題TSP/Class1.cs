using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        // 計算兩點之間的距離平方的函數 (委派) # 用於計算能量值 # 不使用Sqrt()可以更加快運算速度
        public static Func<Point, Point, double> GetDistance = (Point p1, Point p2) => Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2);
        public static double count_energy(ref int[] conf)
        {
            double temp = 0;
            for (int i = 1; i < 25; ++i)
            {
                temp += GetDistance(f.dot[conf[i]], f.dot[conf[i - 1]]);
            }
            return temp + GetDistance(f.dot[conf[0]], f.dot[conf[24]]);
        }
        #region 接受或拒絕新樣本的函數
        // 函數的輸入參數：
        // e1: 當前樣本的能量值
        // e2: 新生成樣本的能量值
        // t: 溫度參數，控制接受或拒絕的機率
        public static bool metro(double e1, double e2, double t)
        {
            if (e2 < e1) return true;
            double p = Math.Exp(-(e2 - e1) / t);
            double bignum = 1E9;
            return (rnd.Next(0, 36768) % bignum < p * bignum);
        }
        #endregion
        #region 隨機產生一組新解
        public static void generate(ref int[] s)
        {
            List<int> indexs = new List<int>();
            for (int i = 0; i < 25; i++)
            {
                indexs.Add(i);
            }
            int cnt = 0;
            while(indexs.Count > 0)
            {
                s[cnt] = indexs[rnd.Next(0, indexs.Count - 1)];
                indexs.Remove(s[cnt++]);
            }
        }
        #endregion
        #region 隨機交換序列中的一組城市順序
        public static void generate1(ref int[] s)
        {
            int ti = rd();
            int tj = ti;
            //使得 ti 與 tj 不相等
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
        #endregion
        #region 隨機選序列中的三個城市互相交換順序
        public static void generate2(ref int[] s)
        {
            int ti = rd();
            int tj = ti;
            int tk = ti;
            //使得 ti 與 tj 與 tk 不相等
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
        #endregion
        #region 隨機交換序列中的兩組城市順序
        public static void generate3(ref int[] s)
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
        #endregion
        #region 以上三種交換方式等概率選擇
        public static void generate0(ref int[] s)
        {
            switch (rnd.Next(0, 3))
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
        #endregion
        public static void swap<T>(ref T a, ref T b)
        {
            T tmp = a; a = b; b = tmp;
        }
    }
}
