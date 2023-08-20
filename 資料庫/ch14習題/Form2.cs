using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ch14習題
{
    public partial class Form2 : Form
    {
        public static string country2;
        public static int goldMedals;
        public static int silverMedals;
        public static int bronzeMedals;
        public event EventHandler DataInputCompleted;
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                country2 = textBox1.Text;
                goldMedals = int.Parse(textBox2.Text);
                silverMedals = int.Parse(textBox3.Text);
                bronzeMedals = int.Parse(textBox4.Text);
                this.Close();
                DataInputCompleted?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception)
            {
                MessageBox.Show("輸入格式錯誤!", "Hint");
            }
        }
    }
}
