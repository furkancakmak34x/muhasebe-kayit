namespace Uygulama
{
    partial class Anasayfa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAlim = new System.Windows.Forms.Button();
            this.btnOdeme = new System.Windows.Forms.Button();
            this.btnBorc = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnKayit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAlim
            // 
            this.btnAlim.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnAlim.Location = new System.Drawing.Point(63, 512);
            this.btnAlim.MaximumSize = new System.Drawing.Size(180, 55);
            this.btnAlim.MinimumSize = new System.Drawing.Size(180, 55);
            this.btnAlim.Name = "btnAlim";
            this.btnAlim.Size = new System.Drawing.Size(180, 55);
            this.btnAlim.TabIndex = 0;
            this.btnAlim.Text = "Alış / Satış";
            this.btnAlim.UseVisualStyleBackColor = true;
            this.btnAlim.Click += new System.EventHandler(this.btnAlim_Click);
            // 
            // btnOdeme
            // 
            this.btnOdeme.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnOdeme.Location = new System.Drawing.Point(595, 512);
            this.btnOdeme.MaximumSize = new System.Drawing.Size(180, 55);
            this.btnOdeme.MinimumSize = new System.Drawing.Size(180, 55);
            this.btnOdeme.Name = "btnOdeme";
            this.btnOdeme.Size = new System.Drawing.Size(180, 55);
            this.btnOdeme.TabIndex = 2;
            this.btnOdeme.Text = "Borç Ödeme";
            this.btnOdeme.UseVisualStyleBackColor = true;
            this.btnOdeme.Click += new System.EventHandler(this.btnOdeme_Click);
            // 
            // btnBorc
            // 
            this.btnBorc.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnBorc.Location = new System.Drawing.Point(249, 512);
            this.btnBorc.MaximumSize = new System.Drawing.Size(180, 55);
            this.btnBorc.MinimumSize = new System.Drawing.Size(180, 55);
            this.btnBorc.Name = "btnBorc";
            this.btnBorc.Size = new System.Drawing.Size(180, 55);
            this.btnBorc.TabIndex = 3;
            this.btnBorc.Text = "Borç / Tahsilat";
            this.btnBorc.UseVisualStyleBackColor = true;
            this.btnBorc.Click += new System.EventHandler(this.btnBorc_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnCikis.Location = new System.Drawing.Point(435, 512);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(154, 55);
            this.btnCikis.TabIndex = 4;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnKayit
            // 
            this.btnKayit.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnKayit.Location = new System.Drawing.Point(781, 512);
            this.btnKayit.MaximumSize = new System.Drawing.Size(180, 55);
            this.btnKayit.MinimumSize = new System.Drawing.Size(180, 55);
            this.btnKayit.Name = "btnKayit";
            this.btnKayit.Size = new System.Drawing.Size(180, 55);
            this.btnKayit.TabIndex = 5;
            this.btnKayit.Text = "Tüm Kayıtlar";
            this.btnKayit.UseVisualStyleBackColor = true;
            this.btnKayit.Click += new System.EventHandler(this.btnKayit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Uygulama.Properties.Resources.logo_tp;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(63, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(898, 250);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            // 
            // Anasayfa
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnKayit);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnBorc);
            this.Controls.Add(this.btnOdeme);
            this.Controls.Add(this.btnAlim);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1024, 600);
            this.MinimumSize = new System.Drawing.Size(1024, 600);
            this.Name = "Anasayfa";
            this.Padding = new System.Windows.Forms.Padding(60, 30, 60, 30);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Anasayfa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAlim;
        private System.Windows.Forms.Button btnOdeme;
        private System.Windows.Forms.Button btnBorc;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Button btnKayit;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}