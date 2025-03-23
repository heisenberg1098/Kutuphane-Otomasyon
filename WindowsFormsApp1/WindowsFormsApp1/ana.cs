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
    public partial class ana : Form
    {
        public ana()
        {
            InitializeComponent();
        }

        private void sqlkod(string kayıt)
        {
            string con = "server=localhost\\SQLEXPRESS;Database=ktphane;Integrated Security=true;";
            SqlConnection baglantı = new SqlConnection(con);
            baglantı.Open();
            SqlCommand komut = new SqlCommand(kayıt, baglantı);
            komut.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable d1 = new DataTable();
            da.Fill(d1);
            dataGridView1.DataSource = d1;

            baglantı.Close();
        }
        private void gosgiz(int i)
        {
            if (i == 1)
            {
                dataGridView1.Visible = false;
                label1.Visible = true;


                label4.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                textBox10.Visible = true;

                textBox2.Visible = true;
                textBox9.Visible = true;
                textBox4.Visible = true;
                textBox3.Visible = true;

            }
            if (i == 0)
            {
                dataGridView1.Visible = true;

                sqlkod("SELECT * FROM kullanici ");
                label1.Visible = false;


                label4.Visible = false;

                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                textBox10.Visible = false;

                textBox2.Visible = false;
                textBox9.Visible = false;
                textBox4.Visible = false;
                textBox3.Visible = false;

            }
        }
        private void boşalt()
        {
            textBox10.Text = null;
            textBox2.Text = null;
            textBox9.Text = null;
            textBox4.Text = null;
            textBox3.Text = null;
        }
        private void ana_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            boşalt();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        int sayac = 1;
        ktphaneDataSet kds = new ktphaneDataSet();
        ktphaneEntities1 db = new ktphaneEntities1();
        private void button2_Click(object sender, EventArgs e)
        {
            if (sayac % 2 == 0)
            {
                button3.Visible = true;
                button4.Visible = true;
                button7.Visible = true;
                button8.Visible = true;
            }
            else
            {
                button3.Visible = false;
                button4.Visible = false;
                button7.Visible = false;
                button8.Visible = false;
                gosgiz(0);
            }
            sayac++;

            string kmt ="select * from kullanici";
            sqlkod(kmt);
        }



        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox10.Visible == true)
            {


                string ad = textBox10.Text;
                string soyad = textBox2.Text;
                string tc = textBox9.Text;
                string no = textBox4.Text;
                string mail = textBox3.Text;
                string kmt = string.Format("INSERT INTO kullanici (kullanici_ad, kullanici_soyad, kullanici_tc, kullanici_mail, kullanici_tel) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", ad, soyad, tc, mail, no);
                sqlkod(kmt);
                string mesaj = string.Format("{0} kişisi eklendi", ad);
                MessageBox.Show(mesaj, "bilgi");

            }
            gosgiz(1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            gosgiz(0);
        }
        int s = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            gosgiz(0);
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("satır seçin", "hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                s++;
                gosgiz(1);
                if (s == 2)
                {

                    string ıd = textBox11.Text;
                    string yad = textBox10.Text;
                    string ysoyad = textBox2.Text;
                    string ytc = textBox9.Text;
                    string yno = textBox4.Text;
                    string ymail = textBox3.Text;
                    sqlkod(string.Format("UPDATE kullanici SET kullanici_ad='{0}',kullanici_soyad='{1}',kullanici_tc='{2}',kullanici_mail='{4}',kullanici_tel='{3}' WHERE kullanici_id={5}", yad, ysoyad, ytc, yno, ymail, ıd));
                    MessageBox.Show(string.Format("{0} kişisi güncellendi", yad, "bilgi", MessageBoxIcon.Information));
                    s = 0;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            gosgiz(0);
            if (string.IsNullOrEmpty(textBox11.Text))
            {
                MessageBox.Show("satır seçin", "hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string ıd = textBox11.Text;
                string msj = string.Format("{0} kişisini silmek istediginize emin misiniz", ıd);
                DialogResult rst = MessageBox.Show(msj, "silme sorusu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rst == DialogResult.Yes)
                {
                    string komut = string.Format("delete from kullanici where kullanici_id={0}", ıd);
                    sqlkod(komut);
                    gosgiz(0);
                    MessageBox.Show("veriler silindi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            ana1 a1 = new ana1();
            a1.Show();
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox11.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }
    }
}
