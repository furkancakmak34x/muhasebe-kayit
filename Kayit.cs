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
    public partial class Kayit : Form
    {
        public Kayit()
        {
            InitializeComponent();
        }

        private void Sorgu()
        {
            if (checkBox1.Checked && checkBox2.Checked)
            {
                if (radioButton1.Checked)
                {
                    Tablo.DataSource = AlimSahisCins(textBox1.Text, textBox2.Text);

                    int tutar = 0;
                    int tonaj = 0;

                    for (int i = 0; i < Tablo.Rows.Count; i++)
                    {
                        if (Tablo.Rows[i].Cells[5].Value != null)
                        {
                            tutar += Convert.ToInt32(Tablo.Rows[i].Cells[5].Value);
                            tonaj += Convert.ToInt32(Tablo.Rows[i].Cells[3].Value);
                        }
                    }

                    label3.Text = "Toplam Tutar : " + Convert.ToString(tutar) + " ₺";
                    label4.Text = "Toplam Tonaj : " + Convert.ToString(tonaj) + " KG";
                }

                else if (radioButton2.Checked)
                {
                    Tablo.DataSource = SatisSahisCins(textBox1.Text, textBox2.Text);

                    int tutar = 0;
                    int tonaj = 0;

                    for (int i = 0; i < Tablo.Rows.Count; i++)
                    {
                        if (Tablo.Rows[i].Cells[5].Value != null)
                        {
                            tutar += Convert.ToInt32(Tablo.Rows[i].Cells[5].Value);
                            tonaj += Convert.ToInt32(Tablo.Rows[i].Cells[3].Value);
                        }
                    }

                    label3.Text = "Toplam Tutar : " + Convert.ToString(tutar) + " ₺";
                    label4.Text = "Toplam Tonaj : " + Convert.ToString(tonaj) + " KG";
                }

                else if (radioButton3.Checked)
                {
                    Tablo2.DataSource = BorcRapor();
                    textBox1.Text = "";
                    textBox2.Text = "";

                }

                else
                {
                    Tablo2.DataSource = AlacakRapor();
                    textBox1.Text = "";
                    textBox2.Text = "";

                }
            }

            else if (checkBox1.Checked && !checkBox2.Checked)
            {
                if (radioButton1.Checked)
                {
                    Tablo.DataSource = AlimSahis(textBox1.Text);

                    int tutar = 0;
                    int tonaj = 0;

                    for (int i = 0; i < Tablo.Rows.Count; i++)
                    {
                        if (Tablo.Rows[i].Cells[5].Value != null)
                        {
                            tutar += Convert.ToInt32(Tablo.Rows[i].Cells[5].Value);
                            tonaj += Convert.ToInt32(Tablo.Rows[i].Cells[3].Value);
                        }
                    }

                    label3.Text = "Toplam Tutar : " + Convert.ToString(tutar) + " ₺";
                    label4.Text = "Toplam Tonaj : " + Convert.ToString(tonaj) + " KG";
                }

                else if (radioButton2.Checked)
                {
                    Tablo.DataSource = SatisSahis(textBox1.Text);

                    int tutar = 0;
                    int tonaj = 0;

                    for (int i = 0; i < Tablo.Rows.Count; i++)
                    {
                        if (Tablo.Rows[i].Cells[5].Value != null)
                        {
                            tutar += Convert.ToInt32(Tablo.Rows[i].Cells[5].Value);
                            tonaj += Convert.ToInt32(Tablo.Rows[i].Cells[3].Value);
                        }
                    }

                    label3.Text = "Toplam Tutar : " + Convert.ToString(tutar) + " ₺";
                    label4.Text = "Toplam Tonaj : " + Convert.ToString(tonaj) + " KG";
                }

                else if (radioButton3.Checked)
                {
                    Tablo2.DataSource = BorcSahis(textBox1.Text);

                    int tutar = 0;

                    for (int i = 0; i < Tablo2.Rows.Count; i++)
                    {
                        if (Tablo2.Rows[i].Cells[2].Value != null)
                        {
                            tutar += Convert.ToInt32(Tablo2.Rows[i].Cells[2].Value);
                        }
                    }

                    label3.Text = "Toplam Tutar : " + Convert.ToString(tutar) + " ₺";
                }

                else if (radioButton4.Checked)
                {
                    Tablo2.DataSource = AlacakSahis(textBox1.Text);

                    int tutar = 0;

                    for (int i = 0; i < Tablo2.Rows.Count; i++)
                    {
                        if (Tablo2.Rows[i].Cells[2].Value != null)
                        {
                            tutar += Convert.ToInt32(Tablo2.Rows[i].Cells[2].Value);
                        }
                    }

                    label3.Text = "Toplam Tutar : " + Convert.ToString(tutar) + " ₺";
                }
            }

            else if (!checkBox1.Checked && checkBox2.Checked)
            {
                if (radioButton1.Checked)
                {
                    Tablo.DataSource = AlimCins(textBox2.Text);

                    int tutar = 0;
                    int tonaj = 0;

                    for (int i = 0; i < Tablo.Rows.Count; i++)
                    {
                        if (Tablo.Rows[i].Cells[5].Value != null)
                        {
                            tutar += Convert.ToInt32(Tablo.Rows[i].Cells[5].Value);
                            tonaj += Convert.ToInt32(Tablo.Rows[i].Cells[3].Value);
                        }
                    }

                    label3.Text = "Toplam Tutar : " + Convert.ToString(tutar) + " ₺";
                    label4.Text = "Toplam Tonaj : " + Convert.ToString(tonaj) + " KG";
                }

                else if (radioButton2.Checked)
                {
                    Tablo.DataSource = SatisCins(textBox2.Text);

                    int tutar = 0;
                    int tonaj = 0;

                    for (int i = 0; i < Tablo.Rows.Count; i++)
                    {
                        if (Tablo.Rows[i].Cells[5].Value != null)
                        {
                            tutar += Convert.ToInt32(Tablo.Rows[i].Cells[5].Value);
                            tonaj += Convert.ToInt32(Tablo.Rows[i].Cells[3].Value);
                        }
                    }

                    label3.Text = "Toplam Tutar : " + Convert.ToString(tutar) + " ₺";
                    label4.Text = "Toplam Tonaj : " + Convert.ToString(tonaj) + " KG";
                }

                else if (radioButton3.Checked)
                {
                    Tablo2.DataSource = BorcRapor();
                    textBox1.Text = "";
                    textBox2.Text = "";
                }

                else
                {
                    Tablo2.DataSource = AlacakRapor();
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }

            else
            {
                if (radioButton1.Checked)
                {
                    Tablo.DataSource = AlimRapor();

                    int tutar = 0;
                    int tonaj = 0;

                    for (int i = 0; i < Tablo.Rows.Count; i++)
                    {
                        if (Tablo.Rows[i].Cells[5].Value != null)
                        {
                            tutar += Convert.ToInt32(Tablo.Rows[i].Cells[5].Value);
                            tonaj += Convert.ToInt32(Tablo.Rows[i].Cells[3].Value);
                        }
                    }

                    label3.Text = "Toplam Tutar : " + Convert.ToString(tutar) + " ₺";
                    label4.Text = "Toplam Tonaj : " + Convert.ToString(tonaj) + " KG";
                }

                else if (radioButton2.Checked)
                {
                    Tablo.DataSource = SatisRapor();

                    int tutar = 0;
                    int tonaj = 0;

                    for (int i = 0; i < Tablo.Rows.Count; i++)
                    {
                        if (Tablo.Rows[i].Cells[5].Value != null)
                        {
                            tutar += Convert.ToInt32(Tablo.Rows[i].Cells[5].Value);
                            tonaj += Convert.ToInt32(Tablo.Rows[i].Cells[3].Value);
                        }
                    }

                    label3.Text = "Toplam Tutar : " + Convert.ToString(tutar) + " ₺";
                    label4.Text = "Toplam Tonaj : " + Convert.ToString(tonaj) + " KG";
                }

                else if (radioButton3.Checked)
                {
                    Tablo2.DataSource = BorcRapor();

                    int tutar = 0;

                    for (int i = 0; i < Tablo2.Rows.Count; i++)
                    {
                        if (Tablo2.Rows[i].Cells[2].Value != null)
                        {
                            tutar += Convert.ToInt32(Tablo2.Rows[i].Cells[2].Value);
                        }
                    }

                    label3.Text = "Toplam Tutar : " + Convert.ToString(tutar) + " ₺";
                }

                else if (radioButton4.Checked)
                {
                    Tablo2.DataSource = AlacakRapor();

                    int tutar = 0;

                    for (int i = 0; i < Tablo2.Rows.Count; i++)
                    {
                        if (Tablo2.Rows[i].Cells[2].Value != null)
                        {
                            tutar += Convert.ToInt32(Tablo2.Rows[i].Cells[2].Value);
                        }
                    }

                    label3.Text = "Toplam Tutar : " + Convert.ToString(tutar) + " ₺";
                }
            }
        }

        private void Kayit_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.icon;
            radioButton1.Checked = true;
            Sorgu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new Anasayfa();
            frm.Show();
            this.Hide();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Tablo.Visible = true;
            Tablo2.Visible = false;
            Tablo.DataSource = AlimRapor();
            Tablo.Columns[0].Visible = false;

            label2.Visible = true;
            textBox2.Visible = true;
            checkBox2.Visible = true;

            label4.Visible = true;

            checkBox1.Checked = false;
            checkBox2.Checked = false;

            textBox1.Text = "";
            textBox2.Text = "";

            Sorgu();

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Tablo.Visible = true;
            Tablo2.Visible = false;
            Tablo.DataSource = SatisRapor();
            Tablo.Columns[0].Visible = false;

            label2.Visible = true;
            textBox2.Visible = true;
            checkBox2.Visible = true;

            label4.Visible = true;

            checkBox1.Checked = false;
            checkBox2.Checked = false;

            textBox1.Text = "";
            textBox2.Text = "";

            Sorgu();
        }    

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Tablo2.Visible = true;
            Tablo.Visible = false;
            Tablo2.DataSource = BorcRapor();
            Tablo2.Columns[0].Visible = false;

            label2.Visible = false;
            textBox2.Visible = false;
            checkBox1.Visible = false;
            checkBox2.Visible = false;

            label4.Visible = false;

            checkBox1.Checked = false;
            checkBox2.Checked = false;

            textBox1.Text = "";
            textBox2.Text = "";

            Sorgu();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            Tablo2.Visible = true;
            Tablo.Visible = false;
            Tablo2.DataSource = AlacakRapor();
            Tablo2.Columns[0].Visible = false;

            label2.Visible = false;
            textBox2.Visible = false;
            checkBox1.Visible = false;
            checkBox2.Visible = false;

            label4.Visible = false;

            checkBox1.Checked = false;
            checkBox2.Checked = false;

            textBox1.Text = "";
            textBox2.Text = "";

            Sorgu();
        }

        private void Tablo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = Tablo.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = Tablo.CurrentRow.Cells[2].Value.ToString();
        }

        private void Tablo2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = Tablo2.CurrentRow.Cells[1].Value.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Sorgu();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Sorgu();       
        }
    }
}
