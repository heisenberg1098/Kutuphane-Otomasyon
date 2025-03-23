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
    public partial class Form1 : Form
    {
        ktphaneEntities1 db = new ktphaneEntities1();
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            kayıt k1 = new kayıt();
            k1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string txtad = textBox1.Text;
            string txtsifre = textBox2.Text;
            var personel = db.personeller.Where(x => x.personel_ad.Equals(txtad)&&x.personel_şifre.Equals(txtsifre)).FirstOrDefault();

            if (personel==null)
            {
                MessageBox.Show("kullanıcı adı veya şifre hatalı");
            }
            
            else
            {
                ana1 ana1 = new ana1();
                ana1.Show();
                this.Hide();
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                textBox2.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {

                ana1 a1 = new ana1();
                this.Hide();
                a1.Show();

            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // TextBox1'e bir şey yazıldıktan sonra Enter tuşuna basıldığında burası çalışır.
                button1.Focus();
            }
        }


    }
}
