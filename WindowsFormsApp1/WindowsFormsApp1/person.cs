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
    public partial class person : Form
    {
        public person()
        {
            InitializeComponent();
        }

        private void ana_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
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
        ktphaneEntities1 db = new ktphaneEntities1();
        private void button2_Click(object sender, EventArgs e)
        {
            if (sayac % 2 == 0)
            {
                button3.Visible = true;
                button4.Visible = true;
                button7.Visible = true;
                button8.Visible = true;
                button10.Visible = true;
                dataGridView1.Visible = true;
            }
            else
            {
                button3.Visible = false;
                button4.Visible = false;
                button7.Visible = false;
                button8.Visible = false;
                button10.Visible = false;
                dataGridView1.Visible = true;
            }
            if (dataGridView1.Visible == true)
            {
                gosgiz(0);
            }

            sayac++;
            sqlkod("select * from personeller");



        }
        int sayyac=0;
        string sifre;
        private void button3_Click(object sender, EventArgs e)
        {
            gosgiz(1);
            sayyac++;

            if (textBox10.Visible == true&&sayyac%2==0)
            {

                string ad = textBox10.Text;
                string soyad = textBox2.Text;
                string tc = textBox9.Text;
                string tel = textBox4.Text;
                string mail = textBox3.Text;
                if (textBox11.Text == textBox12.Text && textBox11.Text.Length >= 5)
                {
                    sifre = textBox11.Text;
                    string kmt = string.Format("INSERT INTO personeller (personel_ad, personel_soyad, personel_tc, personel_tel, personel_mail, personel_şifre) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", ad, soyad, tc, tel, mail, sifre);
                    string con = "server=DESKTOP-S25L9LT\\SQLEXPRESS;Database=ktphane;Integrated Security=true;";
                    SqlConnection baglantı = new SqlConnection(con);
                    baglantı.Open();
                    SqlCommand komut = new SqlCommand(kmt, baglantı);
                    komut.ExecuteNonQuery();
                    baglantı.Close();
                    gosgiz(0);
                }
                else
                {
                    textBox11.BackColor = Color.Red;
                    textBox12.BackColor = Color.Red;
                    MessageBox.Show("lütfen 5 karakterden büyük ve şifrenin aynı oldugundan emin olun", "HATA!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
            dataGridView1.DataSource = d1;
            baglantı.Close();
        }
        private void gosgiz(int i)
        {
            if (i == 1)
            {
                dataGridView1.Visible = false;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label5.Visible = true;
                label4.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                textBox10.Visible = true;
                textBox11.Visible = true;
                textBox12.Visible = true;
                textBox2.Visible = true;
                textBox9.Visible = true;
                textBox4.Visible = true;
                textBox3.Visible = true;
                pictureBox2.Visible = true;
                pictureBox3.Visible = true;
                pictureBox4.Visible = true;
                pictureBox5.Visible = true;
            }
            if (i == 0)
            {
                dataGridView1.Visible = true;

                sqlkod("select * from personeller");
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                textBox10.Visible = false;
                textBox11.Visible = false;
                textBox12.Visible = false;
                textBox2.Visible = false;
                textBox9.Visible = false;
                textBox4.Visible = false;
                textBox3.Visible = false;
                pictureBox5.Visible = false;
                pictureBox4.Visible = false;
                pictureBox3.Visible = false;
                pictureBox2.Visible = false;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            gosgiz(0);
            sqlkod("select * from personeller");

        }
        string per1_ıd;
        string per1_ad;
        string per1_tc;
        string per1_tel;
        string per1_mail;
        string per1_şifre;
        string per1_soyad;

        private void button4_Click(object sender, EventArgs e)
        {
            gosgiz(0);

            if (dataGridView1.RowCount > 0)
            {
                gosgiz(1);

              
                


                per1_ad = textBox10.Text;
                per1_ıd = textBox1.Text;
                per1_soyad = textBox2.Text;
                per1_tc = textBox9.Text;
                per1_tel = textBox4.Text;
                per1_mail = textBox3.Text;
                per1_şifre = textBox11.Text;


                //string komt = string.Format("UPDATE personeller SET personel_ad='{6}',personel_soyad='{1}',personel_tc='{2}',personel_tel='{3}',personel_mail='{4}',personel_şifre='{5}' WHERE personel_ıd={0}", per_ıd,per_soyad,per_tc,per_tel,per_mail,per_şifre,per_ad);


                string msj = string.Format("{0} kişiyi güncellemek istediginizden emin misiniz", per1_ad);

                DialogResult res = MessageBox.Show(msj, "güncelleme işlemi mesajı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    
                    sqlkod(string.Format("UPDATE personeller SET personel_ad='{0}', personel_soyad='{1}', personel_tc='{2}', personel_tel='{3}', personel_mail='{4}',personel_şifre='{5}' WHERE personel_ıd = {6};", per1_ad, per1_soyad, per1_tc, per1_tel, per1_mail, per1_şifre,per1_ıd));
                    MessageBox.Show("veriler başarıyla guncellendi");
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir satır seçin.");
            }

        }


        private void button7_Click(object sender, EventArgs e)
        {
            gosgiz(0);
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("satır seçin", "hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string ıd = textBox1.Text;
                string msj = string.Format("{0} kişisini silmek istediginize emin misiniz", ıd);
                DialogResult rst = MessageBox.Show(msj, "silme sorusu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rst == DialogResult.Yes)
                {
                    string komut = string.Format("delete from personeller where personel_ıd={0}", ıd);
                    sqlkod(komut);
                    gosgiz(0);
                    MessageBox.Show("veriler silindi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            ana1 a1 = new ana1();
            a1.Show();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox11.PasswordChar = '\0';
            pictureBox3.Visible = false;
            pictureBox2.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            textBox12.PasswordChar = '\0';
            pictureBox4.Visible = false;
            pictureBox5.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox11.PasswordChar = '*';
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            textBox12.PasswordChar = '*';
            pictureBox5.Visible = false;
            pictureBox4.Visible = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox12.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }
        int s = 0;
        private void button10_Click(object sender, EventArgs e)
        {
            s++;
            gosgiz(0);
            sqlkod("select * from personel_kabul");
            if (s%2==0)
            {
                gosgiz(1);
                DialogResult dr = MessageBox.Show("kişinin kayıt olmasını onaylıyor musunuz", "kayıt sorusu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    string ad = textBox10.Text;
                    string soyad = textBox2.Text;
                    string tc = textBox9.Text;
                    string mail = textBox3.Text;
                    string tel = textBox4.Text;
                    sifre = textBox11.Text;
                    string kmt = string.Format("INSERT INTO personeller (personel_ad, personel_soyad, personel_tc, personel_tel, personel_mail, personel_şifre) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", ad, soyad, tc, tel, mail, sifre);
                    sqlkod(kmt);

                }
                if (dr==DialogResult.No)
                {
                    string ıd = textBox1.Text;
                    string komut = string.Format("delete from personel_kabul where personel_id={0}", ıd);
                    sqlkod(komut);
                }
            }
        }
    }
}
