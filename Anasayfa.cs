using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Uygulama
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void Anasayfa_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.icon;
        }

        private void btnAlim_Click(object sender, EventArgs e)
        {
            Form frm = new AlimSatim();
            frm.Show();
        }

        private void btnBorc_Click(object sender, EventArgs e)
        {
            Form frm = new BorcAlacak();
            frm.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Uygulamadan çıkış yapmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Form frm = new Login();
                frm.Show();
                this.Hide();
            }
        }

        private void btnOdeme_Click(object sender, EventArgs e)
        {
            Form frm = new Odeme();
            frm.Show();
            this.Hide();
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            Form frm = new Kayit();
            frm.Show();
            this.Hide();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            Form frm = new Info();
            frm.Show();
        }
    }
}
