using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static Uygulama.Processes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Uygulama
{
    public partial class AlimSatim : Form
    {
        public AlimSatim()
        {
            InitializeComponent();
        }

        private void AlimSatim_Load(object sender, EventArgs e)
        {
            textBox6.Text = DateTime.Now.ToString("dd MMMM yyyy");
            this.Icon = Properties.Resources.icon;
            label7.Visible = false;
            textBox7.Enabled = false;
            textBox7.Visible = false;
            checkBox1.Enabled = false;
            checkBox1.Visible = false;

            radioButton2.Checked = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (checkBox1.Checked)
                {
                    if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0 || textBox5.Text.Length == 0 || textBox6.Text.Length == 0)
                    {
                        MessageBox.Show("Boşlukları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else if (MessageBox.Show("Girilen değerler üzerinden satın alım işlemi yapılacaktır. Onaylıyor musunuz?", "Satın Alma İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            Connect();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = _conn;
                            cmd.Parameters.AddWithValue("@isim", textBox1.Text.ToString());
                            cmd.Parameters.AddWithValue("@cins", textBox2.Text.ToString());
                            cmd.Parameters.AddWithValue("@tonaj", textBox3.Text.ToString());
                            cmd.Parameters.AddWithValue("@fiyat", textBox4.Text.ToString());
                            cmd.Parameters.AddWithValue("@tutar", textBox5.Text.ToString());
                            cmd.Parameters.AddWithValue("@tarih", textBox6.Text.ToString());
                            cmd.CommandText = "INSERT INTO ALIM (ISIM, CINS, TONAJ, FIYAT, TUTAR, TARIH) VALUES (@isim, @cins, @tonaj, @fiyat, @tutar, @tarih)";
                            cmd.ExecuteNonQuery();
                            Disconnect(_conn);

                            MessageBox.Show("Satın alım işlemi başarılı.", "Satın Alma İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0 || textBox5.Text.Length == 0 || textBox6.Text.Length == 0 || textBox7.Text.Length == 0 || (Convert.ToInt32(textBox7.Text) > Convert.ToInt32(textBox5.Text)))
                    {
                        MessageBox.Show("Boşlukları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else if (MessageBox.Show("Girilen değerler üzerinden satın alım işlemi yapılacaktır. Onaylıyor musunuz?", "Satın Alma İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        double tutar = Convert.ToDouble(textBox5.Text) - Convert.ToDouble(textBox7.Text);

                        try
                        {
                            Connect();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = _conn;
                            cmd.Parameters.AddWithValue("@isim", textBox1.Text.ToString());
                            cmd.Parameters.AddWithValue("@cins", textBox2.Text.ToString());
                            cmd.Parameters.AddWithValue("@tonaj", textBox3.Text.ToString());
                            cmd.Parameters.AddWithValue("@fiyat", textBox4.Text.ToString());
                            cmd.Parameters.AddWithValue("@tutar", textBox5.Text.ToString());
                            cmd.Parameters.AddWithValue("@tarih", textBox6.Text.ToString());
                            cmd.Parameters.AddWithValue("@borc", tutar.ToString());
                            cmd.CommandText = "INSERT INTO ALIM (ISIM, CINS, TONAJ, FIYAT, TUTAR, TARIH) VALUES (@isim, @cins, @tonaj, @fiyat, @tutar, @tarih)";
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = "IF EXISTS (SELECT * FROM BORC WHERE ISIM = @isim) BEGIN UPDATE BORC SET TUTAR = TUTAR + @borc, TARIH = @tarih WHERE ISIM = @isim END ELSE BEGIN INSERT INTO BORC (ISIM, TUTAR, TARIH) VALUES (@isim, @borc, @tarih) END";
                            cmd.ExecuteNonQuery();
                            Disconnect(_conn);

                            MessageBox.Show("Satın alım işlemi başarılı.", "Satın Alma İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Disconnect(_conn);
                        }
                    }
                } 
            }

            else if (!radioButton1.Checked)
            {
                if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0 || textBox5.Text.Length == 0 || textBox6.Text.Length == 0)
                {
                    MessageBox.Show("Boşlukları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (MessageBox.Show("Girilen değerler üzerinden satın alım işlemi yapılacaktır. Onaylıyor musunuz?", "Satın Alma İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        Connect();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = _conn;
                        cmd.Parameters.AddWithValue("@isim", textBox1.Text.ToString());
                        cmd.Parameters.AddWithValue("@cins", textBox2.Text.ToString());
                        cmd.Parameters.AddWithValue("@tonaj", textBox3.Text.ToString());
                        cmd.Parameters.AddWithValue("@fiyat", textBox4.Text.ToString());
                        cmd.Parameters.AddWithValue("@tutar", textBox5.Text.ToString());
                        cmd.Parameters.AddWithValue("@tarih", textBox6.Text.ToString());

                        cmd.CommandText = "INSERT INTO ALIM (ISIM, CINS, TONAJ, FIYAT, TUTAR, TARIH) VALUES (@isim, @cins, @tonaj, @fiyat, @tutar, @tarih)";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "IF EXISTS (SELECT * FROM BORC WHERE ISIM = @isim) BEGIN UPDATE BORC SET TUTAR = TUTAR + @tutar, TARIH = @tarih WHERE ISIM = @isim END ELSE BEGIN INSERT INTO BORC (ISIM, TUTAR, TARIH) VALUES (@isim, @tutar, @tarih) END";
                        cmd.ExecuteNonQuery();
                        Disconnect(_conn);

                        MessageBox.Show("Satın alım işlemi başarılı.", "Satın Alma İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Disconnect(_conn);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (checkBox1.Checked)
                {
                    if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0 || textBox5.Text.Length == 0 || textBox6.Text.Length == 0)
                    {
                        MessageBox.Show("Boşlukları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else if (MessageBox.Show("Girilen değerler üzerinden satış işlemi yapılacaktır. Onaylıyor musunuz?", "Satış İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            Connect();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = _conn;
                            cmd.Parameters.AddWithValue("@isim", textBox1.Text.ToString());
                            cmd.Parameters.AddWithValue("@cins", textBox2.Text.ToString());
                            cmd.Parameters.AddWithValue("@tonaj", textBox3.Text.ToString());
                            cmd.Parameters.AddWithValue("@fiyat", textBox4.Text.ToString());
                            cmd.Parameters.AddWithValue("@tutar", textBox5.Text.ToString());
                            cmd.Parameters.AddWithValue("@tarih", textBox6.Text.ToString());
                            cmd.CommandText = "INSERT INTO SATIS (ISIM, CINS, TONAJ, FIYAT, TUTAR, TARIH) VALUES (@isim, @cins, @tonaj, @fiyat, @tutar, @tarih)";
                            cmd.ExecuteNonQuery();
                            Disconnect(_conn);

                            MessageBox.Show("Satış işlemi başarılı.", "Satış İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Disconnect(_conn);
                        }
                    }
                }

                else
                {
                    if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0 || textBox5.Text.Length == 0 || textBox6.Text.Length == 0 || textBox7.Text.Length == 0 || (Convert.ToInt32(textBox7.Text) > Convert.ToInt32(textBox5.Text)))
                    {
                        MessageBox.Show("Boşlukları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else if (MessageBox.Show("Girilen değerler üzerinden satış işlemi yapılacaktır. Onaylıyor musunuz?", "Satış İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        double tutar = Convert.ToDouble(textBox5.Text) - Convert.ToDouble(textBox7.Text);

                        try
                        {
                            Connect();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = _conn;
                            cmd.Parameters.AddWithValue("@isim", textBox1.Text.ToString());
                            cmd.Parameters.AddWithValue("@cins", textBox2.Text.ToString());
                            cmd.Parameters.AddWithValue("@tonaj", textBox3.Text.ToString());
                            cmd.Parameters.AddWithValue("@fiyat", textBox4.Text.ToString());
                            cmd.Parameters.AddWithValue("@tutar", textBox5.Text.ToString());
                            cmd.Parameters.AddWithValue("@tarih", textBox6.Text.ToString());
                            cmd.Parameters.AddWithValue("@tahsilat", tutar.ToString());
                            cmd.CommandText = "INSERT INTO SATIS (ISIM, CINS, TONAJ, FIYAT, TUTAR, TARIH) VALUES (@isim, @cins, @tonaj, @fiyat, @tutar, @tarih)";
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = "IF EXISTS (SELECT * FROM ALACAK WHERE ISIM = @isim) BEGIN UPDATE ALACAK SET TUTAR = TUTAR + @tahsilat, TARIH = @tarih WHERE ISIM = @isim END ELSE BEGIN INSERT INTO ALACAK (ISIM, TUTAR, TARIH) VALUES (@isim, @tahsilat, @tarih) END";
                            cmd.ExecuteNonQuery();
                            Disconnect(_conn);

                            MessageBox.Show("Satış işlemi başarılı.", "Satış İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Disconnect(_conn);
                        }
                    }
                }
            }

            else if (!radioButton1.Checked)
            {
                if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0 || textBox5.Text.Length == 0 || textBox6.Text.Length == 0)
                {
                    MessageBox.Show("Boşlukları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (MessageBox.Show("Girilen değerler üzerinden satış işlemi yapılacaktır. Onaylıyor musunuz?", "Satış İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        Connect();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = _conn;
                        cmd.Parameters.AddWithValue("@isim", textBox1.Text.ToString());
                        cmd.Parameters.AddWithValue("@cins", textBox2.Text.ToString());
                        cmd.Parameters.AddWithValue("@tonaj", textBox3.Text.ToString());
                        cmd.Parameters.AddWithValue("@fiyat", textBox4.Text.ToString());
                        cmd.Parameters.AddWithValue("@tutar", textBox5.Text.ToString());
                        cmd.Parameters.AddWithValue("@tarih", textBox6.Text.ToString());
                        cmd.CommandText = "INSERT INTO SATIS (ISIM, CINS, TONAJ, FIYAT, TUTAR, TARIH) VALUES (@isim, @cins, @tonaj, @fiyat, @tutar, @tarih)";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "IF EXISTS (SELECT * FROM ALACAK WHERE ISIM = @isim) BEGIN UPDATE ALACAK SET TUTAR = TUTAR + @tutar, TARIH = @tarih WHERE ISIM = @isim END ELSE BEGIN INSERT INTO ALACAK (ISIM, TUTAR, TARIH) VALUES (@isim, @tutar, @tarih) END";
                        cmd.ExecuteNonQuery();
                        Disconnect(_conn);

                        MessageBox.Show("Satış işlemi başarılı.", "Satış İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Disconnect(_conn);
                    }
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
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length != 0 && textBox4.Text.Length != 0)
            {
                string textBox = textBox4.Text;
                string fiyat = textBox.Replace('.', ',');
                double x = Convert.ToDouble(textBox3.Text);
                double y = Convert.ToDouble(fiyat);
                double z = x * y;

                textBox5.Text = z.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form frm = new Anasayfa();
            frm.Show();
            this.Hide();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label7.Visible = true;
            textBox7.Enabled = true;
            textBox7.Visible = true;
            checkBox1.Enabled = true;
            checkBox1.Visible = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label7.Visible = false;
            textBox7.Enabled = false;
            textBox7.Visible = false;
            checkBox1.Enabled = false;
            checkBox1.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox7.Text = textBox5.Text;
                textBox7.ReadOnly = true;
            }

            else 
            {
                textBox7.Text = "";
                textBox7.ReadOnly = false;
            }
        }
    }
}
