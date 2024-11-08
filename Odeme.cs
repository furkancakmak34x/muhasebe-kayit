using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Uygulama.Processes;

namespace Uygulama
{
    public partial class Odeme : Form
    {
        public Odeme()
        {
            InitializeComponent();
        }

        private void Yenile()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void Odeme_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.icon; 
            
            radioButton1.Checked = true;
            Tablo.DataSource = BorcRapor();

            Tablo.Columns[0].Visible = false;

            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;

            Yenile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new Anasayfa();
            frm.Show();
            this.Hide();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "Borç";
            Tablo.DataSource = BorcRapor();
            Tablo.Columns[0].Visible = false;
            checkBox1.Checked = false;
            Yenile();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "Tahsilat";
            Tablo.DataSource = AlacakRapor();
            Tablo.Columns[0].Visible = false;
            checkBox1.Checked = false;
            Yenile();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox4.Text = textBox2.Text;
                textBox4.ReadOnly = true;
            }

            else
            {
                textBox4.Text = "";
                textBox4.ReadOnly = false;
            }

            textBox1.Text = Tablo.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = Tablo.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = Tablo.CurrentRow.Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (checkBox1.Checked)
                {
                    if (MessageBox.Show("Girilen değerler üzerinden borç ödeme işlemi yapılacaktır. Onaylıyor musunuz?", "Borç Ödeme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            Connect();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = _conn;
                            cmd.Parameters.AddWithValue("@isim", Tablo.CurrentRow.Cells[1].Value.ToString());
                            cmd.CommandText = "DELETE FROM BORC WHERE ISIM = @isim";
                            cmd.ExecuteNonQuery();
                            Disconnect(_conn);

                            MessageBox.Show("Borç ödeme işlemi başarılı.", "Borç Ödeme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Yenile();
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Disconnect(_conn);
                        }
                    }
                }

                else if (!checkBox1.Checked)
                {
                    if (textBox4.Text.Length == 0 || (Convert.ToInt32(textBox4.Text) > Convert.ToInt32(textBox2.Text)))
                    {
                        MessageBox.Show("Hatalı giriş yaptınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else if (MessageBox.Show("Girilen değerler üzerinden borç ödeme işlemi yapılacaktır. Onaylıyor musunuz?", "Borç Ödeme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int tutar = Convert.ToInt32(textBox2.Text) - Convert.ToInt32(textBox4.Text);
                        
                        try
                        {
                            Connect();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = _conn;
                            cmd.Parameters.AddWithValue("@isim", Tablo.CurrentRow.Cells[1].Value.ToString());
                            cmd.Parameters.AddWithValue("@tarih", Tablo.CurrentRow.Cells[3].Value.ToString());
                            cmd.Parameters.AddWithValue("@tutar", tutar);
                            cmd.CommandText = "UPDATE BORC SET TUTAR = @tutar, TARIH = @tarih WHERE ISIM = @isim";
                            cmd.ExecuteNonQuery();
                            Disconnect(_conn);

                            MessageBox.Show("Borç ödeme işlemi başarılı.", "Borç Ödeme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Yenile();
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Disconnect(_conn);
                        }
                    }
                }
            }

            else if (radioButton2.Checked)
            {
                if (checkBox1.Checked)
                {
                    if (MessageBox.Show("Girilen değerler üzerinden tahsilat işlemi yapılacaktır. Onaylıyor musunuz?", "Tahsilat İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            Connect();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = _conn;
                            cmd.Parameters.AddWithValue("@isim", Tablo.CurrentRow.Cells[1].Value.ToString());
                            cmd.CommandText = "DELETE FROM ALACAK WHERE ISIM = @isim";
                            cmd.ExecuteNonQuery();
                            Disconnect(_conn);

                            MessageBox.Show("Tahsilat işlemi başarılı.", "Tahsilat İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Yenile();
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Disconnect(_conn);
                        }
                    }
                }

                else if (!checkBox1.Checked)
                {
                    if (textBox4.Text.Length == 0 || (Convert.ToInt32(textBox4.Text) > Convert.ToInt32(textBox2.Text)))
                    {
                        MessageBox.Show("Hatalı giriş yaptınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else if (MessageBox.Show("Girilen değerler üzerinden tahsilat işlemi yapılacaktır. Onaylıyor musunuz?", "Tahsilat İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int tutar = Convert.ToInt32(textBox2.Text) - Convert.ToInt32(textBox4.Text);

                        try
                        {
                            Connect();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = _conn;
                            cmd.Parameters.AddWithValue("@isim", Tablo.CurrentRow.Cells[1].Value.ToString());
                            cmd.Parameters.AddWithValue("@tarih", Tablo.CurrentRow.Cells[3].Value.ToString());
                            cmd.Parameters.AddWithValue("@tutar", tutar);
                            cmd.CommandText = "UPDATE ALACAK SET TUTAR = @tutar, TARIH = @tarih WHERE ISIM = @isim";
                            cmd.ExecuteNonQuery();
                            Disconnect(_conn);

                            MessageBox.Show("Tahsilat işlemi başarılı.", "Tahsilat İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Yenile();
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Disconnect(_conn);
                        }
                    }
                }
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Tablo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = Tablo.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = Tablo.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = Tablo.CurrentRow.Cells[3].Value.ToString();
            checkBox1.Checked = false;
        }
    }
}
