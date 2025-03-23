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
    public partial class istatistikler : Form
    {
        public istatistikler()
        {
            InitializeComponent();
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
       
        
            
        
        private void istatistikler_Load(object sender, EventArgs e)
        {
            string con = "server=DESKTOP-S25L9LT\\SQLEXPRESS;Database=ktphane;Integrated Security=true;";
            string kayıt = "SELECT t.tur_ad, COUNT(*) AS kitap_count  FROM kitaplar k INNER JOIN tur t ON k.kitap_tur = t.tur_id GROUP BY t.tur_ad;";
            string kayıt2 = "SELECT kitap_yayınevi, COUNT(*) FROM kitaplar GROUP BY kitap_yayınevi";
            string kayıt3 = "SELECT personel_ad, COUNT(*) FROM personeller  GROUP BY personel_ad";
            using (SqlConnection baglanti = new SqlConnection(con))
            {
                baglanti.Open();

                using (SqlCommand komut = new SqlCommand(kayıt, baglanti))
                using (SqlDataReader dr1 = komut.ExecuteReader())
                {
                    while (dr1.Read())
                    {
                        chart1.Series["Kategoriler"].Points.AddXY(dr1[0], dr1[1]);
                    }
                }

                using (SqlCommand komut2 = new SqlCommand(kayıt2, baglanti))
                using (SqlDataReader dr2 = komut2.ExecuteReader())
                {
                    while (dr2.Read())
                    {
                        chart2.Series["yayın_evleri"].Points.AddXY(dr2[0], dr2[1]);
                    }
                }
                using (SqlCommand komut3 = new SqlCommand(kayıt3, baglanti))
                using (SqlDataReader dr3 = komut3.ExecuteReader())
                {
                    while (dr3.Read())
                    {
                        chart3.Series["çalışan_sayısı"].Points.AddXY(dr3[0], dr3[1]);
                    }
                }
            }

        }
    }
}
