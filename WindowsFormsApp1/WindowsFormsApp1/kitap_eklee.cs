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
    public partial class kitap_eklee : Form
    {
        public kitap_eklee()
        {
            InitializeComponent();
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
        private void boşalt()
        {
            textBox1.Text = null;
            textBox2.Text = null;
            comboBox1.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox7.Text = null;
            textBox8.Text = null;
            textBox9.Text = null;
            textBox10.Text = null;

        }
        string sqlSorgu = "SELECT kitaplar.kitap_id, kitaplar.kitap_ad, tur.tur_ad, kitaplar.kitap_yazar, kitaplar.kitap_tur, kitaplar.kitap_cevirmen, kitaplar.kitap_sayfa, kitaplar.kitap_adet, kitaplar.kitap_yayınevi, kitaplar.kitap_emanet, kitaplar.kitap_eldevar FROM kitaplar INNER JOIN tur ON kitaplar.kitap_tur = tur.tur_id";


        private void gosgiz(int i)
        {
            if (i == 1)
            {
                dataGridView1.Visible = false;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                comboBox1.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                textBox9.Visible = true;
                textBox10.Visible = true;
                pictureBox1.Visible = true;
            }
            if (i == 0)
            {
                dataGridView1.Visible = true;

                sqlkod(sqlSorgu);
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                comboBox1.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;
                pictureBox1.Visible = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ana a1 = new ana();
            a1.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            person p1 = new person();
            p1.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        string eldeVar;
        string cevirmen;
        int kitapTur;
        private void button9_Click(object sender, EventArgs e)
        {
            gosgiz(1);

            if (!string.IsNullOrEmpty(textBox1.Text))
            {

                string kitapAd = textBox1.Text;
                string yazarAd = textBox2.Text;
                kitapTur = comboBox1.SelectedIndex;
                if (string.IsNullOrEmpty(textBox4.Text))
                {
                    cevirmen = "null";
                }
                else
                {
                    cevirmen = textBox4.Text;
                }
                string sayfaSayisi = textBox5.Text;
                string adet = textBox7.Text;
                string yayinevi = textBox8.Text;
                string emanet = textBox9.Text;
                if (string.IsNullOrEmpty(textBox10.Text))
                {
                    eldeVar = "null";
                }
                else
                {
                    eldeVar = textBox10.Text;
                }

                string kmt = string.Format("INSERT INTO kitaplar (kitap_ad, kitap_yazar, kitap_tur, kitap_cevirmen, kitap_sayfa, kitap_adet, kitap_yayınevi, kitap_emanet, kitap_eldevar) VALUES('{0}', '{1}', {2}, {3}, {4}, {5}, '{6}', {7}, {8})", kitapAd, yazarAd, kitapTur, cevirmen, sayfaSayisi, adet, yayinevi, emanet, eldeVar);
                string con = "server=DESKTOP-S25L9LT\\SQLEXPRESS;Database=ktphane;Integrated Security=true;";
                SqlConnection baglantı = new SqlConnection(con);
                baglantı.Open();
                SqlCommand komut = new SqlCommand(kmt, baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show(string.Format("{0} eklendi", kitapAd), "bilgi");
                gosgiz(0);
            }
            boşalt();
        }

        private void kitap_eklee_Load(object sender, EventArgs e)
        {
            gosgiz(0);
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            gosgiz(0);
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("satır seçin", "hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string ıd = textBox6.Text;
                string msj = string.Format("{0} kişisini silmek istediginize emin misiniz", ıd);
                DialogResult rst = MessageBox.Show(msj, "silme sorusu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rst == DialogResult.Yes)
                {
                    string komut = string.Format("delete from kitaplar where kitap_id={0}", ıd);
                    sqlkod(komut);
                    gosgiz(0);
                    MessageBox.Show("veriler silindi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox6.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            string ındex = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox1.SelectedIndex = int.Parse(ındex);



        }
        int bekle = 0;
        private void button3_Click_1(object sender, EventArgs e)
        {
            bekle++;
            gosgiz(0);
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("satır seçin", "hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                gosgiz(1);
                if (bekle % 2 == 0)
                {

                    
                    string kitapid = textBox6.Text;
                    string kitapad = textBox1.Text;
                    string yazarAd = textBox2.Text;
                    int kitapTur = comboBox1.SelectedIndex;
                    if (string.IsNullOrEmpty(textBox4.Text))
                    {
                        cevirmen = "null";
                    }
                    else
                    {
                        cevirmen = "'" + textBox4.Text + "'";
                    }
                    string sayfaSayisi = textBox5.Text;
                    string adet = textBox7.Text;
                    string yayinevi = textBox8.Text;
                    string emanet = textBox9.Text;
                    if (string.IsNullOrEmpty(textBox10.Text))
                    {
                        eldeVar = "null";
                    }
                    else
                    {
                        eldeVar = textBox10.Text;
                    }
                    sqlkod(string.Format("UPDATE kitaplar SET kitap_ad='{0}', kitap_yazar='{1}', kitap_tur='{2}', kitap_cevirmen={3}, kitap_sayfa='{4}', kitap_adet='{5}', kitap_yayınevi='{6}', kitap_emanet='{7}', kitap_eldevar={8} WHERE kitap_id={9}", kitapad, yazarAd, kitapTur, cevirmen, sayfaSayisi, adet, yayinevi, emanet, eldeVar, kitapid));
                    MessageBox.Show(string.Format("{0} kişisi güncellendi", kitapad), "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gosgiz(0);
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ana1 a1 = new ana1();
            a1.Show();
            this.Close();
        }
    }
}
