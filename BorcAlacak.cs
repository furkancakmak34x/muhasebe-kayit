using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Uygulama.Processes;

namespace Uygulama
{
    public partial class BorcAlacak : Form
    {
        public BorcAlacak()
        {
            InitializeComponent();
        }

        private void BorcAlacak_Load(object sender, EventArgs e)
        {
            textBox3.Text = DateTime.Now.ToString("dd MMMM yyyy");
            this.Icon = Properties.Resources.icon;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0)
            {
                MessageBox.Show("Boşlukları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (MessageBox.Show("Girilen değerler üzerinden borç ekleme işlemi yapılacaktır. Onaylıyor musunuz?", "Borç Ekleme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Connect();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = _conn;
                    cmd.Parameters.AddWithValue("@isim", textBox1.Text.ToString());
                    cmd.Parameters.AddWithValue("@tutar", textBox2.Text.ToString());
                    cmd.Parameters.AddWithValue("@tarih", textBox3.Text.ToString());
                    cmd.CommandText = "IF EXISTS (SELECT * FROM BORC WHERE ISIM = @isim) BEGIN UPDATE BORC SET TUTAR = TUTAR + @tutar, TARIH = @tarih WHERE ISIM = @isim END ELSE BEGIN INSERT INTO BORC (ISIM, TUTAR, TARIH) VALUES (@isim, @tutar, @tarih) END";
                    cmd.ExecuteNonQuery();
                    Disconnect(_conn);

                    MessageBox.Show("Borç ekleme işlemi başarılı.", "Borç Ekleme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Disconnect(_conn);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0)
            {
                MessageBox.Show("Boşlukları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (MessageBox.Show("Girilen değerler üzerinden tahsilat ekleme işlemi yapılacaktır. Onaylıyor musunuz?", "Tahsilat Ekleme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Connect();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = _conn;
                    cmd.Parameters.AddWithValue("@isim", textBox1.Text.ToString());
                    cmd.Parameters.AddWithValue("@tutar", textBox2.Text.ToString());
                    cmd.Parameters.AddWithValue("@tarih", textBox3.Text.ToString());
                    cmd.CommandText = "IF EXISTS (SELECT * FROM ALACAK WHERE ISIM = @isim) BEGIN UPDATE ALACAK SET TUTAR = TUTAR + @tutar, TARIH = @tarih WHERE ISIM = @isim END ELSE BEGIN INSERT INTO ALACAK (ISIM, TUTAR, TARIH) VALUES (@isim, @tutar, @tarih) END";
                    cmd.ExecuteNonQuery();
                    Disconnect(_conn);

                    MessageBox.Show("Ekleme işlemi başarılı.", "Tahsilat Ekleme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Disconnect(_conn);
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form frm = new Anasayfa();
            frm.Show();
            this.Hide();
        }
    }
}
