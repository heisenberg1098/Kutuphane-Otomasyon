using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class kayıt : Form
    {
        public kayıt()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            string[] kod = new string[32] { "q", "w", "e", "r", "t", "y", "u", "ı", "o", "p", "ğ", "ü", "a", "s", "d", "f", "g", "h", "j", "k", "l", "ş", "i", "z", "x", "c", "v", "b", "n", "m", "ö", "ç" };
            Random ran = new Random();
            for (int i = 0; i < 5; i++)
            {
                label5.Text += kod[ran.Next(0, 31)];
            }
            
        }
        private void sqlkod(string kayıt)
        {
            string con = "server=DESKTOP-S25L9LT\\SQLEXPRESS;Database=ktphane;Integrated Security=true;";
            SqlConnection baglantı = new SqlConnection(con);
            baglantı.Open();
            SqlCommand komut = new SqlCommand(kayıt, baglantı);
            komut.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable d1 = new DataTable();
            da.Fill(d1);
            baglantı.Close();
        }
        string sifre;
        private void button2_Click(object sender, EventArgs e)
        {
            if (label5.Text==textBox4.Text)
            {
                if (textBox2.Text == textBox3.Text)
                {
                    if (textBox2.Text.Length >= 6&& textBox2.Text.Length <= 15)
                    {
                        string ad = textBox1.Text;
                        string soyad = textBox5.Text;
                        string tc = textBox8.Text;
                        string tel = textBox7.Text;
                        string mail = textBox6.Text;
                        sifre = textBox2.Text;
                        string kmt = string.Format("INSERT INTO personel_kabul (personel_ad, personel_soyad, personel_tc, personel_tel, personel_mail, personel_şifre) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", ad, soyad, tc, tel, mail, sifre);
                        sqlkod(kmt);
                        MessageBox.Show("talebiniz alındı", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Şifre en az 6 haneli enfazla 15 haneli olabilir");
                    }
                }
                else
                {
                    MessageBox.Show("Şifre Eşleşmiyor");
                }

            }
            else
            {
                MessageBox.Show("Kodunuz Yanlış");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '\0';
            pictureBox3.Visible = false;
            pictureBox2.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            textBox3.PasswordChar = '\0';
            pictureBox4.Visible = false;
            pictureBox5.Visible = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            textBox3.PasswordChar = '*';
            pictureBox5.Visible = false;
            pictureBox4.Visible = true;
        }

        private void kayıt_Load(object sender, EventArgs e)
        {
            pictureBox2.Height = textBox3.Height;
            pictureBox3.Height = textBox3.Height;
            pictureBox4.Height = textBox3.Height;
            pictureBox5.Height = textBox3.Height;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
