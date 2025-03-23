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
    public partial class ayarlar : Form
    {
        public ayarlar()
        {
            InitializeComponent();
        }

        private void ayarlar_Load(object sender, EventArgs e)
        {
            
            string con = "server=DESKTOP-S25L9LT\\SQLEXPRESS;Database=ktphane;Integrated Security=true;";
            string kayıt = "SELECT * FROM ayar "; // Veri çekecek SQL sorgusu
            SqlConnection baglantı = new SqlConnection(con);
            baglantı.Open();
            SqlCommand komut = new SqlCommand(kayıt, baglantı);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable d1 = new DataTable();
            da.Fill(d1);
            trackBar1.Value = int.Parse(d1.Rows[0][0].ToString()); // İlk satırdaki ilk sütunu alıyoruz
            trackBar2.Value = int.Parse(d1.Rows[0][1].ToString()); // İlk satırdaki ilk sütunu alıyoruz
            float deger = float.Parse(d1.Rows[0][3].ToString());
            trackBar4.Value = (int)(deger * 2.0f); ; // ceza sure
            trackBar3.Value = int.Parse(d1.Rows[0][2].ToString()); // ceza tl
           
            baglantı.Close();
            textBox1.Text = trackBar2.Value.ToString();
            textBox2.Text = trackBar1.Value.ToString();
            textBox3.Text = trackBar3.Value.ToString()+ " Gün";
            textBox4.Text = (trackBar4.Value / 2.0).ToString()+ " \u20BA";
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
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox2.Text = trackBar1.Value.ToString();
            sqlkod(string.Format("UPDATE ayar SET alınabilir_kitap={0}", textBox2.Text));
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            
            textBox1.Text = trackBar2.Value.ToString();
            sqlkod(string.Format("UPDATE ayar SET teslim_suresi={0}", textBox1.Text));
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            textBox3.Text = trackBar3.Value.ToString()+" Gün";
            sqlkod(string.Format("UPDATE ayar SET ceza_sure={0}", trackBar3.Value.ToString()));
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            float deger = (float)trackBar4.Value / 2.0f;
            textBox4.Text = (deger ).ToString() + " \u20BA";
            sqlkod(string.Format("UPDATE ayar SET gec_ceza_tl={0}", deger.ToString().Replace(',', '.')));
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (label6.Text=="çizgi açık")
            {
                label6.Text = "çizgi kapalı";
                trackBar1.TickStyle = TickStyle.None;
                trackBar2.TickStyle = TickStyle.None;
                trackBar3.TickStyle = TickStyle.None;
                trackBar4.TickStyle = TickStyle.None;
            }
            else if (label6.Text == "çizgi kapalı")
            {
                label6.Text = "çizgi açık";
                trackBar1.TickStyle = TickStyle.BottomRight;
                trackBar2.TickStyle = TickStyle.BottomRight;
                trackBar3.TickStyle = TickStyle.BottomRight;
                trackBar4.TickStyle = TickStyle.BottomRight;
            }
        }
    }
}

