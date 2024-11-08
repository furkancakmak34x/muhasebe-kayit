using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static Uygulama.Processes;

namespace Uygulama
{
    public partial class Info : Form
    {
        public Info()
        {
            InitializeComponent();
        }

        private void Info_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.icon;

            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;

                cmd.CommandText = "SELECT SUM(CAST(TUTAR AS INT)) FROM ALIM";
                cmd.ExecuteNonQuery();
                int alim = (int)cmd.ExecuteScalar();

                cmd.CommandText = "SELECT SUM(CAST(TUTAR AS INT)) FROM SATIS";
                cmd.ExecuteNonQuery();
                int satis = (int)cmd.ExecuteScalar();
                Disconnect(_conn);

                label1.Text = "Toplam Alım: " + alim.ToString() + " ₺";
                label2.Text = "Toplam Satış: " + satis.ToString() + " ₺";
                label3.Text = "Net Durum: " + (satis - alim).ToString() + " ₺";
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Disconnect(_conn);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new Anasayfa();
            frm.Show();
            this.Hide();
        }

        private void Info_DoubleClick(object sender, EventArgs e)
        {
            Form frm = new Admin();
            frm.Show();
            this.Hide();
        }
    }
}
