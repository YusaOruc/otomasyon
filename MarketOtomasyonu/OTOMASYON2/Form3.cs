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
    public partial class Form3 : Form
    {
        OleDbConnection baglantı = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database2.mdb");
        OleDbCommand komut;
        OleDbDataAdapter adtr;
        DataTable tablo = new DataTable();
        

        public Form3()
        {
            InitializeComponent();
            
        }
        private void Form3_Load(object sender, EventArgs e)
        {

            
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if(textBox3.Text== "Ad")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.DimGray;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text== "")
            {
                textBox3.Text = "Ad";
                textBox3.ForeColor = Color.DimGray;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Soyad")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.DimGray;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Soyad";
                textBox4.ForeColor = Color.DimGray;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1.Text== "Kullanıcı")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.DimGray;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Kullanıcı";
                textBox1.ForeColor = Color.DimGray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if(textBox2.Text== "Sifre")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.DimGray;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Sifre";
                textBox2.ForeColor = Color.DimGray;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Profil GirisForm = new Profil();
            GirisForm.ShowDialog();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


        
        private void listele()
        {
            tablo.Clear();
            baglantı.Open();
            komut = new OleDbCommand("select * from Bilgiler", baglantı);
            adtr = new OleDbDataAdapter(komut);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglantı.Close();

        }




        private void button1_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            komut=new OleDbCommand("select * from Bilgiler where Kullanıcı = '"+textBox1.Text+"'", baglantı);
            OleDbDataReader reader = komut.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("Kullanıcı adınız daha önceden alınmış.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                baglantı.Close();
            }
            else
            {
                komut = new OleDbCommand("INSERT into Bilgiler(Kullanıcı,Sifre,Ad,Soyad,Yas,Mail,Telefon) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')", baglantı);

                komut.ExecuteNonQuery();
                baglantı.Close();
                listele();
                MessageBox.Show("Üye Olundu...", "ÜYE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            




        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            if (textBox7.Text == "Telefon")
            {
                textBox7.Text = "";
                textBox7.ForeColor = Color.DimGray;
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                textBox7.Text = "Telefon";
                textBox7.ForeColor = Color.DimGray;
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Yas")
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.DimGray;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "Yas";
                textBox5.ForeColor = Color.DimGray;
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Text == "E-Posta")
            {
                textBox6.Text = "";
                textBox6.ForeColor = Color.DimGray;
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                textBox6.Text = "E-Posta";
                textBox6.ForeColor = Color.DimGray;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listele();
            
        }
    }
}
//Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\bin\Debug\Database2.mdb
//OleDbDataAdapter ekle = new OleDbDataAdapter("INSERT into Bilgiler2(Kullanıcı,Sifre,Ad,Soyad,Yas,E-Posta,Telefon) values ('" + textBox7.Text + "','" + textBox6.Text + "','" + textBox5.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", baglantı);