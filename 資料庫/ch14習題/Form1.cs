using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ch14習題
{
    public partial class Form1 : Form
    {
        public static SqlConnection db;
        public Form1()
        {
            InitializeComponent();
            string path = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;";
            db = new SqlConnection(path);
            function();
        }
        public void function()
        {
            db.Open();
            SqlCommand cmd = new SqlCommand("SELECT TOP 1000 [國名] ,[金牌] ,[銀牌] ,[銅牌] FROM [dbo].[Table]", db);
            SqlDataReader reader = cmd.ExecuteReader();
            dgv.Columns.Clear();
            dgv.Rows.Clear();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                dgv.Columns.Add(reader.GetName(i), reader.GetName(i));
            }
            while (reader.Read())
            {
                string country = reader.GetString(0);
                int goldMedals = reader.GetInt32(1);
                int silverMedals = reader.GetInt32(2);
                int bronzeMedals = reader.GetInt32(3);
                dgv.Rows.Add(new string[] { country, goldMedals.ToString(), silverMedals.ToString(), bronzeMedals.ToString() });
            }
            db.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (Form2 f2 = new Form2())
            {
                f2.DataInputCompleted += Form2_DataInputCompleted;//完成將執行的函式
                DialogResult result = f2.ShowDialog();
                if (result == DialogResult.OK)
                {
                    //Nothing...
                }
            }
        }
        private void Form2_DataInputCompleted(object sender, EventArgs e)
        {
            db.Open();
            SqlCommand cmd = new SqlCommand($"INSERT INTO [dbo].[Table] (國名,金牌,銀牌,銅牌) VALUES (N'{Form2.country2}',{Form2.goldMedals},{Form2.silverMedals},{Form2.bronzeMedals})", db);
            cmd.ExecuteNonQuery();
            db.Close();
            function();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
