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
    public partial class Admin : Form
    {
        string command;
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null)
            {
                MessageBox.Show("Boşlukları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else 
            {
                command = textBox1.Text;

                try
                {
                    Connect();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = _conn;
                    cmd.CommandText = command;
                    SqlDataReader reader = cmd.ExecuteReader();
                    Disconnect(_conn);

                    MessageBox.Show("Bitti.", "SQL Sorgusu", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            Form frm = new Anasayfa();
            frm.Show();
            this.Hide();
        }
    }
}
