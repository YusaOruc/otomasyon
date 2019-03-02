using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace OTOMASYON2
{
    public partial class Profil : Form
    {
        public static string GidenBilgi = "";

        private void Form2_Load(object sender, EventArgs e)
        {
           
        }

        public Profil()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ad = textBox1.Text;
            string sifre = textBox2.Text;
            OleDbConnection baglantı = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database2.mdb");
            OleDbCommand komut = new OleDbCommand();
            baglantı.Open();
            komut.Connection = baglantı;
            komut.CommandText = "Select * FROM Bilgiler where Kullanıcı='" + textBox1.Text + "'AND Sifre='" + textBox2.Text + "'";
            OleDbDataReader oku = komut.ExecuteReader();
            
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Eksik giriş yaptınız.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                if (oku.Read())
                {
                    GidenBilgi = textBox1.Text;
                    this.Hide();
                    Form1 AnaForm = new Form1();
                    AnaForm.ShowDialog();
                    
                    
                    
                    
                }
              
                    
              
                else
                {
                    MessageBox.Show("Lütfen giriş bilgilerinizi kontrol ediniz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            baglantı.Close();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Kullanıcı adı")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.LightGray;
            }
            
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Kullanıcı adı";
                textBox1.ForeColor = Color.DimGray;
            }
            
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Şifre")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.LightGray;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Şifre";
                textBox2.ForeColor = Color.DimGray;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 Sifre = new Form3();
            Sifre.ShowDialog();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show(textBox2.Text, "şifre", MessageBoxButtons.OK);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }
    }
}
//Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\bin\Debug\Database2.mdb
