using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Uygulama.Processes;

namespace Uygulama
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Uygulamadan çıkış yapmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Process.Start("shutdown", "/s /f /t 0");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == password)
            {
                MessageBox.Show("Giriş başarılı. Hoşgeldiniz Bülent Çakmak.", "Giriş Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form frm = new Anasayfa();
                frm.Show();
                this.Hide();
            }

            else if (textBox1.Text == password2)
            {
                MessageBox.Show("Giriş başarılı. Hoşgeldiniz Furkan Çakmak.", "Giriş Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form frm = new Anasayfa();
                frm.Show();
                this.Hide();
            }

            else if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Parola kısmı boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                MessageBox.Show("Hatalı giriş yaptınız, tekrar deneyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.icon;
        }
    }
}
