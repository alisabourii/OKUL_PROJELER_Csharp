using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace sinavHazirlik
{
    public partial class Form1 : Form
    {
        string connStr = "Server=localhost; Database=test2; uid=root; pwd=";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            goster();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO `test2`.`sinavtest` (`okulNo`, `adSoyad`, `sinif`, `not`) VALUES ('"+textBox3.Text+"', '"+textBox1.Text+"', '"+textBox2.Text+"', '"+textBox4.Text+"');";
            islem(sql);
        }



        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "Delete FROM `test2`.`sinavtest` WHERE `okulNo` = " + textBox3.Text + "";           
            islem(sql);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE `test2`.`sinavtest` SET `adSoyad` = '"+textBox1.Text+ "',`sinif` ='"+textBox2.Text+ "', `not`='"+textBox4.Text+"' WHERE `okulNo` = '" + textBox3.Text + "'";
            islem(sql);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM test2.sinavtest WHERE `okulNo` = '" + textBox3.Text + "'";
            ara(sql);
        }

        public void islem(string sql)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    goster();
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }
        public void goster()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string sql = "SELECT * FROM test2.sinavtest;";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }

            }
            catch (Exception ee) { MessageBox.Show(ee.Message); }
        }

        public void ara(string sql) 
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows.Count > 0)
                        MessageBox.Show("Kayıt Bulundu.","Bulundu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Kayıt Bulunmadı.","Bulunmadı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ee) { MessageBox.Show(ee.Message); }
        }
    }
}
