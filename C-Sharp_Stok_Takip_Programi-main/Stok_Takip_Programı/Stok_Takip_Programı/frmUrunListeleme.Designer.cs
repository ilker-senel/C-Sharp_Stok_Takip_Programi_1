namespace Stok_Takip_Programı
{
    partial class frmUrunListeleme
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSatisFiyati_ = new System.Windows.Forms.TextBox();
            this.txtAlisFiyati_ = new System.Windows.Forms.TextBox();
            this.txtMiktari_ = new System.Windows.Forms.TextBox();
            this.txtUrunadi_ = new System.Windows.Forms.TextBox();
            this.txtKategori_ = new System.Windows.Forms.TextBox();
            this.txtBarkodNo_ = new System.Windows.Forms.TextBox();
            this.btnSil = new System.Windows.Forms.Button();
            this.txtBarkodNoAra = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbKategori = new System.Windows.Forms.ComboBox();
            this.cmbMarka = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnMarkaGuncelle = new System.Windows.Forms.Button();
            this.txtMarka_ = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(326, 104);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(542, 241);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(124, 266);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(92, 32);
            this.btnGuncelle.TabIndex = 36;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(46, 231);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 35;
            this.label8.Text = "Satış Fiyatı";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(54, 198);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 34;
            this.label9.Text = "Alış Fiyatı";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(72, 165);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 16);
            this.label10.TabIndex = 33;
            this.label10.Text = "Miktarı";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(60, 132);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 16);
            this.label11.TabIndex = 32;
            this.label11.Text = "Ürün Adı";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(73, 99);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 16);
            this.label12.TabIndex = 31;
            this.label12.Text = "Marka";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(61, 66);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 16);
            this.label13.TabIndex = 30;
            this.label13.Text = "Kategori";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(46, 33);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 16);
            this.label14.TabIndex = 29;
            this.label14.Text = "Barkod No";
            // 
            // txtSatisFiyati_
            // 
            this.txtSatisFiyati_.Location = new System.Drawing.Point(124, 227);
            this.txtSatisFiyati_.Name = "txtSatisFiyati_";
            this.txtSatisFiyati_.Size = new System.Drawing.Size(134, 22);
            this.txtSatisFiyati_.TabIndex = 28;
            // 
            // txtAlisFiyati_
            // 
            this.txtAlisFiyati_.Location = new System.Drawing.Point(124, 194);
            this.txtAlisFiyati_.Name = "txtAlisFiyati_";
            this.txtAlisFiyati_.Size = new System.Drawing.Size(134, 22);
            this.txtAlisFiyati_.TabIndex = 27;
            // 
            // txtMiktari_
            // 
            this.txtMiktari_.Location = new System.Drawing.Point(124, 161);
            this.txtMiktari_.Name = "txtMiktari_";
            this.txtMiktari_.Size = new System.Drawing.Size(134, 22);
            this.txtMiktari_.TabIndex = 26;
            // 
            // txtUrunadi_
            // 
            this.txtUrunadi_.Location = new System.Drawing.Point(124, 128);
            this.txtUrunadi_.Name = "txtUrunadi_";
            this.txtUrunadi_.Size = new System.Drawing.Size(134, 22);
            this.txtUrunadi_.TabIndex = 25;
            // 
            // txtKategori_
            // 
            this.txtKategori_.Enabled = false;
            this.txtKategori_.Location = new System.Drawing.Point(124, 60);
            this.txtKategori_.Name = "txtKategori_";
            this.txtKategori_.Size = new System.Drawing.Size(134, 22);
            this.txtKategori_.TabIndex = 24;
            // 
            // txtBarkodNo_
            // 
            this.txtBarkodNo_.Location = new System.Drawing.Point(124, 27);
            this.txtBarkodNo_.Name = "txtBarkodNo_";
            this.txtBarkodNo_.Size = new System.Drawing.Size(134, 22);
            this.txtBarkodNo_.TabIndex = 23;
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(888, 104);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(92, 32);
            this.btnSil.TabIndex = 39;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // txtBarkodNoAra
            // 
            this.txtBarkodNoAra.Location = new System.Drawing.Point(640, 54);
            this.txtBarkodNoAra.Name = "txtBarkodNoAra";
            this.txtBarkodNoAra.Size = new System.Drawing.Size(179, 22);
            this.txtBarkodNoAra.TabIndex = 40;
            this.txtBarkodNoAra.TextChanged += new System.EventHandler(this.txtBarkodNoAra_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(454, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 16);
            this.label1.TabIndex = 41;
            this.label1.Text = "Barkod No\'ya göre arama";
            // 
            // cmbKategori
            // 
            this.cmbKategori.FormattingEnabled = true;
            this.cmbKategori.Location = new System.Drawing.Point(326, 379);
            this.cmbKategori.Name = "cmbKategori";
            this.cmbKategori.Size = new System.Drawing.Size(134, 24);
            this.cmbKategori.TabIndex = 42;
            this.cmbKategori.SelectedIndexChanged += new System.EventHandler(this.cmbKategori_SelectedIndexChanged);
            // 
            // cmbMarka
            // 
            this.cmbMarka.FormattingEnabled = true;
            this.cmbMarka.Location = new System.Drawing.Point(326, 425);
            this.cmbMarka.Name = "cmbMarka";
            this.cmbMarka.Size = new System.Drawing.Size(134, 24);
            this.cmbMarka.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 433);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 45;
            this.label2.Text = "Marka";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 387);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 44;
            this.label3.Text = "Kategori";
            // 
            // btnMarkaGuncelle
            // 
            this.btnMarkaGuncelle.Location = new System.Drawing.Point(479, 387);
            this.btnMarkaGuncelle.Name = "btnMarkaGuncelle";
            this.btnMarkaGuncelle.Size = new System.Drawing.Size(101, 62);
            this.btnMarkaGuncelle.TabIndex = 46;
            this.btnMarkaGuncelle.Text = "Marka Güncelle";
            this.btnMarkaGuncelle.UseVisualStyleBackColor = true;
            this.btnMarkaGuncelle.Click += new System.EventHandler(this.btnMarkaGuncelle_Click);
            // 
            // txtMarka_
            // 
            this.txtMarka_.Enabled = false;
            this.txtMarka_.Location = new System.Drawing.Point(124, 93);
            this.txtMarka_.Name = "txtMarka_";
            this.txtMarka_.Size = new System.Drawing.Size(134, 22);
            this.txtMarka_.TabIndex = 47;
            // 
            // frmUrunListeleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1043, 521);
            this.Controls.Add(this.txtMarka_);
            this.Controls.Add(this.btnMarkaGuncelle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbMarka);
            this.Controls.Add(this.cmbKategori);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBarkodNoAra);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtSatisFiyati_);
            this.Controls.Add(this.txtAlisFiyati_);
            this.Controls.Add(this.txtMiktari_);
            this.Controls.Add(this.txtUrunadi_);
            this.Controls.Add(this.txtKategori_);
            this.Controls.Add(this.txtBarkodNo_);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmUrunListeleme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürün Listeleme";
            this.Load += new System.EventHandler(this.frmUrunListeleme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtSatisFiyati_;
        private System.Windows.Forms.TextBox txtAlisFiyati_;
        private System.Windows.Forms.TextBox txtMiktari_;
        private System.Windows.Forms.TextBox txtUrunadi_;
        private System.Windows.Forms.TextBox txtKategori_;
        private System.Windows.Forms.TextBox txtBarkodNo_;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.TextBox txtBarkodNoAra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbKategori;
        private System.Windows.Forms.ComboBox cmbMarka;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnMarkaGuncelle;
        private System.Windows.Forms.TextBox txtMarka_;
    }
}