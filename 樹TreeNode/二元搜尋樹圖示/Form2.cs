using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 二元搜尋樹圖示
{
    public partial class Form2 : Form
    {
        public static List<int> col;
        public event EventHandler DataInputCompleted;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                col = textBox1.Text.Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
                textBox1.Text = "";
                this.Close();
                DataInputCompleted?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception)
            {
                MessageBox.Show("輸入格式錯誤!\r\n格式參考:\r\n1.輸入一個整數\r\n2.以空格或逗號分隔多個整數", "提示");
            }
        }
    }
}
