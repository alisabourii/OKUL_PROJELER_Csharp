using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace KitapUygulama
{
    public partial class Form1: Form
    {
        string connStr = "Server=localhost; Database=test2; uid=root; pwd=";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM test2.kutuphanetab";
            goster(sql);
        }


        

        private void button1_Click(object sender, EventArgs e)
        {
            string durum = "";
            if (checkBox1.Checked) durum = "Var";
            else durum = "Yok";
            string sql = "INSERT INTO `test2`.`kutuphanetab` (`kitapAdi`, `yazarAdi`, `sayfaSayisi`, `durum`) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + durum + "');";
            islem(sql);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM `test2`.`kutuphanetab` WHERE id='"+textBox4.Text+"'";
            islem(sql);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string durum = "";
            if (checkBox1.Checked) durum = "Var";
            else durum = "Yok";
            string sql = "UPDATE `test2`.`kutuphanetab` SET `kitapAdi`='"+textBox1.Text+ "',`yazarAdi`='" + textBox2.Text+ "', `sayfaSayisi`='"+textBox3.Text+ "',`durum`='"+durum+"'    WHERE id='" + textBox4.Text + "'";
            islem(sql);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM test2.kutuphanetab where kitapAdi LIKE '%"+textBox4.Text+"%';";
            goster(sql);
        }

        public void goster(string sql)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connStr);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        public void islem(string sql)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                goster("SELECT * FROM test2.kutuphanetab");
            }
        }
    }
}
