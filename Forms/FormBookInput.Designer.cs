namespace CitraPersadaCatalog.Forms
{
    partial class FormBookInput
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
            lblTitle = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label10 = new Label();
            cmbJenjang = new ComboBox();
            cmbKelas = new ComboBox();
            cmbMataPelajaran = new ComboBox();
            cmbJenisBuku = new ComboBox();
            txtJudulBuku = new TextBox();
            txtHargaJual = new TextBox();
            txtCoverPath = new TextBox();
            btnPilihCover = new Button();
            btnSimpan = new Button();
            btnBatal = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(147, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Tambah Buku";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 55);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 1;
            label2.Text = "Jenjang";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 95);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 2;
            label3.Text = "Kelas";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 135);
            label4.Name = "label4";
            label4.Size = new Size(125, 15);
            label4.TabIndex = 3;
            label4.Text = "Mata Pelajaran / Tema";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 175);
            label5.Name = "label5";
            label5.Size = new Size(62, 15);
            label5.TabIndex = 4;
            label5.Text = "Jenis Buku";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 215);
            label6.Name = "label6";
            label6.Size = new Size(65, 15);
            label6.TabIndex = 5;
            label6.Text = "Judul Buku";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(25, 255);
            label7.Name = "label7";
            label7.Size = new Size(62, 15);
            label7.TabIndex = 6;
            label7.Text = "Harga Jual";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(25, 295);
            label10.Name = "label10";
            label10.Size = new Size(69, 15);
            label10.TabIndex = 9;
            label10.Text = "Cover Lokal";
            // 
            // cmbJenjang
            // 
            cmbJenjang.FormattingEnabled = true;
            cmbJenjang.Location = new Point(200, 47);
            cmbJenjang.Name = "cmbJenjang";
            cmbJenjang.Size = new Size(163, 23);
            cmbJenjang.TabIndex = 10;
            // 
            // cmbKelas
            // 
            cmbKelas.FormattingEnabled = true;
            cmbKelas.Location = new Point(200, 87);
            cmbKelas.Name = "cmbKelas";
            cmbKelas.Size = new Size(163, 23);
            cmbKelas.TabIndex = 11;
            // 
            // cmbMataPelajaran
            // 
            cmbMataPelajaran.FormattingEnabled = true;
            cmbMataPelajaran.Location = new Point(200, 127);
            cmbMataPelajaran.Name = "cmbMataPelajaran";
            cmbMataPelajaran.Size = new Size(163, 23);
            cmbMataPelajaran.TabIndex = 12;
            // 
            // cmbJenisBuku
            // 
            cmbJenisBuku.FormattingEnabled = true;
            cmbJenisBuku.Location = new Point(200, 167);
            cmbJenisBuku.Name = "cmbJenisBuku";
            cmbJenisBuku.Size = new Size(163, 23);
            cmbJenisBuku.TabIndex = 13;
            // 
            // txtJudulBuku
            // 
            txtJudulBuku.Location = new Point(200, 207);
            txtJudulBuku.Name = "txtJudulBuku";
            txtJudulBuku.Size = new Size(272, 23);
            txtJudulBuku.TabIndex = 14;
            // 
            // txtHargaJual
            // 
            txtHargaJual.Location = new Point(200, 247);
            txtHargaJual.Name = "txtHargaJual";
            txtHargaJual.Size = new Size(163, 23);
            txtHargaJual.TabIndex = 15;
            // 
            // txtCoverPath
            // 
            txtCoverPath.Location = new Point(200, 287);
            txtCoverPath.Name = "txtCoverPath";
            txtCoverPath.Size = new Size(272, 23);
            txtCoverPath.TabIndex = 16;
            // 
            // btnPilihCover
            // 
            btnPilihCover.Location = new Point(481, 287);
            btnPilihCover.Name = "btnPilihCover";
            btnPilihCover.Size = new Size(75, 23);
            btnPilihCover.TabIndex = 17;
            btnPilihCover.Text = "Pilih Cover";
            btnPilihCover.UseVisualStyleBackColor = true;
            btnPilihCover.Click += btnPilihCover_Click;
            // 
            // btnSimpan
            // 
            btnSimpan.BackColor = Color.Chartreuse;
            btnSimpan.Location = new Point(397, 324);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(75, 23);
            btnSimpan.TabIndex = 18;
            btnSimpan.Text = "Simpan";
            btnSimpan.UseVisualStyleBackColor = false;
            btnSimpan.Click += btnSimpan_Click;
            // 
            // btnBatal
            // 
            btnBatal.Location = new Point(316, 324);
            btnBatal.Name = "btnBatal";
            btnBatal.Size = new Size(75, 23);
            btnBatal.TabIndex = 19;
            btnBatal.Text = "Batal";
            btnBatal.UseVisualStyleBackColor = true;
            btnBatal.Click += btnBatal_Click;
            // 
            // FormBookInput
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(569, 364);
            Controls.Add(btnBatal);
            Controls.Add(btnSimpan);
            Controls.Add(btnPilihCover);
            Controls.Add(txtCoverPath);
            Controls.Add(txtHargaJual);
            Controls.Add(txtJudulBuku);
            Controls.Add(cmbJenisBuku);
            Controls.Add(cmbMataPelajaran);
            Controls.Add(cmbKelas);
            Controls.Add(cmbJenjang);
            Controls.Add(label10);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblTitle);
            Name = "FormBookInput";
            Text = "FormBookInput";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label10;
        private ComboBox cmbJenjang;
        private ComboBox cmbKelas;
        private ComboBox cmbMataPelajaran;
        private ComboBox cmbJenisBuku;
        private TextBox txtJudulBuku;
        private TextBox txtHargaJual;
        private TextBox txtCoverPath;
        private Button btnPilihCover;
        private Button btnSimpan;
        private Button btnBatal;
    }
}