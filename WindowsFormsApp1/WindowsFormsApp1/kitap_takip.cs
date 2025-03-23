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
    public partial class kitap_takip : Form
    {
        public kitap_takip()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        private void ssqlkod(string kayıt)
        {
            SqlConnection bağlantı = new SqlConnection("server=localhost\\SQLEXPRESS;Database=ktphane;Integrated Security=true;");
            bağlantı.Open();
            SqlCommand komut = new SqlCommand(kayıt, bağlantı);
            komut.ExecuteNonQuery();
            bağlantı.Close();


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
        private void sqlkod2(string kayıt)
        {
            string con = "server=localhost\\SQLEXPRESS;Database=ktphane;Integrated Security=true;";
            SqlConnection baglantı = new SqlConnection(con);
            baglantı.Open();
            SqlCommand komut = new SqlCommand(kayıt, baglantı);
            komut.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable d1 = new DataTable();
            da.Fill(d1);
            dataGridView2.DataSource = d1;


            baglantı.Close();
        }
        private void sqlkod3(string kayıt)
        {
            string con = "server=localhost\\SQLEXPRESS;Database=ktphane;Integrated Security=true;";
            SqlConnection baglantı = new SqlConnection(con);
            baglantı.Open();
            SqlCommand komut = new SqlCommand(kayıt, baglantı);
            komut.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable d1 = new DataTable();
            da.Fill(d1);
            dataGridView3.DataSource = d1;


            baglantı.Close();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            ana1 a1 = new ana1();
            a1.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private string degeroku(int index, string sutun, string tablo)
        {
            string deger = null;
            string connectionString = "server=localhost\\SQLEXPRESS;Database=ktphane;Integrated Security=true;";
            string query = string.Format("SELECT {0} FROM {1}", sutun, tablo); // SQL sorgusu

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection); // SqlCommand oluştur
                connection.Open(); // Bağlantıyı aç

                SqlDataReader reader = command.ExecuteReader(); // Verileri oku

                // Okunan her satır için işlemleri yap
                while (reader.Read())
                {
                    // Sütunun değerini al ve işlem yap
                    deger = reader.GetString(index); // 0 indeksi, sütunun indeksi

                }

                reader.Close(); // Okuyucuyu kapat
            }
            return deger;
        }
        private void tekdeger()
        {
            sqlkod(string.Format("select * from kullanici WHERE kullanici_ad LIKE '%{0}%'", textBox1.Text));
            if (dataGridView1.Rows.Count == 2)
            {
                textBox4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                label16.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                label15.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                if (string.IsNullOrEmpty(dataGridView1.CurrentRow.Cells[6].Value.ToString()))
                    label12.Text = "cezasız";
                else
                    label12.Text = "cezalı";

                label13.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                label14.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            sqlkod2(string.Format("SELECT kitaplar.kitap_id, kitaplar.kitap_ad, tur.tur_ad, kitap_yazar, kitap_cevirmen, kitap_sayfa, kitap_yayınevi FROM kitaplar INNER JOIN tur ON kitaplar.kitap_tur = tur.tur_id WHERE kitap_ad LIKE '%{0}%'", textBox2.Text));
            if (dataGridView2.Rows.Count == 2)
            {
                textBox3.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                label7.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                label8.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                label10.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                if (string.IsNullOrEmpty(label10.Text))
                {
                    label10.Text = "çevirmen yok";
                }
                label11.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
                label9.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(textBox3.Text) && string.IsNullOrEmpty(textBox4.Text)))
            {
                string kullaniciid = textBox3.Text;
                string kitapid = textBox4.Text;
                ssqlkod(string.Format("DELETE from alinan_kitaplar WHERE kitap_id = {0} AND alankisi_id = {1}", kitapid, kullaniciid));
                ssqlkod(string.Format("  update kullanici set alınan_kitap -=1 WHERE kullanici_id={0}", kullaniciid));
                MessageBox.Show("başarıyla gerçekleşti", "kitap işlem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("kullanici id veya kitap id boş", "hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            label7.Text = null;
            label8.Text = null;
            label9.Text = null;
            label10.Text = null;
            label11.Text = null;
            label12.Text = null;
            label13.Text = null;
            label14.Text = null;
            label15.Text = null;
            label16.Text = null;

            textBox1.Text = null;
            textBox2.Text = null;
        }

        private void button7_Click(object sender, EventArgs e)
        {

            string ad = textBox1.Text;
            string kitapad = textBox2.Text;
            string kullaniciid = textBox4.Text;
            string kitapid = textBox3.Text;
     
            sqlkod3(string.Format("select * from alinan_kitaplar WHERE kitap_id = {0} AND alankisi_id = {1}", kitapid, kullaniciid));
            if (dataGridView3.RowCount > 0)
            {

                DateTime tarih = Convert.ToDateTime(dataGridView3.CurrentRow.Cells[3].Value.ToString());
                dateTimePicker2.Value = tarih;
                ssqlkod(string.Format("UPDATE  alinan_kitaplar SET alıs_tarihi = '{0}' WHERE kitap_id = {1} AND alankisi_id = {2}", (tarih.AddDays(7)).ToString("yyyy/MM/dd"), kitapid, kullaniciid));
                MessageBox.Show("süreniz bir hafta daha uzadı", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("dogru kişileri seçtiginizden emin olun", "hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ktphaneEntities1 ke1 = new ktphaneEntities1();
            string kitap_ad = textBox2.Text;
            string ktp_alanogr = textBox1.Text;
            DateTime tarih = dateTimePicker3.Value;
            string sqlTarih = tarih.ToString("yyyy-MM-dd HH:mm:ss");
            sqlkod3(string.Format("select alınan_kitap from kullanici where kullanici_id={0}", textBox4.Text));
            int alinan_kitap_sayisi = int.Parse(dataGridView3.CurrentRow.Cells[0].Value.ToString());
            sqlkod3("SELECT * FROM ayar ");
            int alinabilir_kitap = int.Parse(dataGridView3.CurrentRow.Cells[0].Value.ToString());
            if (!string.IsNullOrEmpty(label12.Text) && label12.Text == "cezasız")
            {
                if (!string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox4.Text))
                {
                    if (alinan_kitap_sayisi < alinabilir_kitap)
                    {
                        
                        string kitap_id = textBox3.Text;
                        string alankisi_id = textBox4.Text;
                        ssqlkod(string.Format("INSERT INTO alinan_kitaplar(kitap_id,alankisi_id,alıs_tarihi) VALUES ({0},{1},'{2}')", kitap_id, alankisi_id, sqlTarih));
                        ssqlkod(string.Format("UPDATE kullanici SET alınan_kitap += 1 WHERE kullanici_id = {0}", alankisi_id));
 
                        MessageBox.Show("başarıyla kaydedildi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Alınan kitap sayısı çok fazla", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Kitap ID veya Alankisi ID boş olamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Kullanıcı cezalı veya bilgiler eksik", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);



        }

        private void kitap_takip_Load(object sender, EventArgs e)
        {
            sqlkod3("select * from alinan_kitaplar");
            DateTime tarih = Convert.ToDateTime(dataGridView3.CurrentRow.Cells[3].Value.ToString());
            dateTimePicker2.Value = tarih;
            sqlkod3("SELECT * FROM ayar ");
            String gun = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            this.kitaplarTableAdapter.Fill(this.ktphaneDataSet.kitaplar);
            this.ayarTableAdapter.Fill(this.ktphaneDataSet.ayar);
            this.kullaniciTableAdapter.Fill(this.ktphaneDataSet.kullanici);
            sqlkod2("SELECT kitaplar.kitap_id, kitaplar.kitap_ad, tur.tur_ad, kitap_yazar, kitap_cevirmen, kitap_sayfa, kitap_yayınevi FROM kitaplar INNER JOIN tur ON kitaplar.kitap_tur = tur.tur_id;");
            ToolTip tt = new ToolTip();
            tt.SetToolTip(textBox1, "kitabı alacak kişinin ismini girin."); //textbox uzerine gelince çalışan ipucu
            tt.SetToolTip(textBox2, "kitabın ismini girin.");



            sqlkod3("SELECT * FROM alinan_kitaplar ");
            for (int i = 0; i < dataGridView3.Rows.Count; i++)//alınan kitapların stununu dolaşıp ceza verecek
            {
                sqlkod3("SELECT * FROM ayar ");
                int cezasure = Convert.ToInt32(dataGridView3.CurrentRow.Cells[2].Value);
                DateTime suan = DateTime.Now;
                sqlkod3("SELECT * FROM alinan_kitaplar ");
                // Kontrol edilen tarih ile şu anki tarih arasındaki farkı bulun
                TimeSpan fark = suan - Convert.ToDateTime(dataGridView3.Rows[i].Cells[3].Value);
                int gunFark = fark.Days;

                sqlkod3("SELECT * FROM kullanici ");
                string mevcutceza = dataGridView3.CurrentRow.Cells[7].Value.ToString();
                string cezatarih = dataGridView3.CurrentRow.Cells[8].Value.ToString();
                if (gunFark >= int.Parse(gun) && mevcutceza == "0")
                {
                    sqlkod3("SELECT * FROM alinan_kitaplar ");
                    int kullaniciid = Convert.ToInt32(dataGridView3.Rows[i].Cells[2].Value);

                    ssqlkod(string.Format("UPDATE kullanici SET kullanici_ceza=1 WHERE kullanici_id={0}", kullaniciid));
                    ssqlkod(string.Format("UPDATE kullanici SET kullanici_ceza_tarih='{1}' WHERE kullanici_id={0}", kullaniciid, suan.ToString("yyyy-MM-dd HH:mm:ss")));

                }

                else if (mevcutceza == "1" && (Convert.ToDateTime(cezatarih) - suan).Days <= 0)
                {
                    int kullaniciid = Convert.ToInt32(dataGridView3.Rows[i].Cells[2].Value);
                    ssqlkod(string.Format("UPDATE kullanici SET kullanici_ceza=0 WHERE kullanici_id={0}", kullaniciid));
                    ssqlkod(string.Format("UPDATE kullanici SET kullanici_ceza_tarih=null WHERE kullanici_id={0}", kullaniciid));
                }

                sqlkod3("SELECT * FROM alinan_kitaplar ");
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tekdeger();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            label7.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            label8.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            label10.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            if (string.IsNullOrEmpty(label10.Text))
            {
                label10.Text = "çevirmen yok";
            }
            label11.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            label9.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            label16.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            label15.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == "True")
                label12.Text = "cezalı";
            else
                label12.Text = "cezasız";

            label13.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            label14.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                // Textbox'ın içeriğini temizle
                textBox1.Clear();
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            label16.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            label15.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == "True")
                label12.Text = "cezalı";
            else
                label12.Text = "cezasız";

            label13.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            label14.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }
    }
}
