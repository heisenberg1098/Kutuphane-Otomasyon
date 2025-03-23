using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ana1 : Form
    {
        public ana1()
        {
            InitializeComponent();
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

        private void button9_Click(object sender, EventArgs e)
        {
            kitap_eklee ke1 = new kitap_eklee();
            ke1.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            istatistikler i1 = new istatistikler();
            i1.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ayarlar a1 = new ayarlar();
            a1.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            hakkında h1 = new hakkında();
            h1.Show();
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            kitap_takip kt1 = new kitap_takip();
            kt1.Show();
            this.Close();
        }
    }
}
