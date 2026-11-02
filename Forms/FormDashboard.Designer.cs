namespace CitraPersadaCatalog.Forms
{
    partial class FormDashboard
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
            components = new System.ComponentModel.Container();
            pnlSidebar = new Panel();
            lblAppName = new Label();
            panel1 = new Panel();
            btnBuatKatalog = new Button();
            btnTambahBuku = new Button();
            lblCompanyName = new Label();
            lblPageTitle = new Label();
            panel2 = new Panel();
            panelContent = new Panel();
            panelTable = new Panel();
            dgvBuku = new DataGridView();
            panelPreview = new Panel();
            picCover = new PictureBox();
            panel3 = new Panel();
            btnResetFilter = new Button();
            label4 = new Label();
            txtCari = new TextBox();
            label3 = new Label();
            cmbJenjang = new ComboBox();
            label2 = new Label();
            cmbKelas = new ComboBox();
            label1 = new Label();
            cmbJenisBuku = new ComboBox();
            cmsBuku = new ContextMenuStrip(components);
            menuEditBuku = new ToolStripMenuItem();
            menuHapusBuku = new ToolStripMenuItem();
            btnDataBuku = new Button();
            btnKatalog = new Button();
            btnPengaturan = new Button();
            pnlSidebar.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panelContent.SuspendLayout();
            panelTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBuku).BeginInit();
            panelPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picCover).BeginInit();
            panel3.SuspendLayout();
            cmsBuku.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.Pink;
            pnlSidebar.BorderStyle = BorderStyle.FixedSingle;
            pnlSidebar.Controls.Add(btnPengaturan);
            pnlSidebar.Controls.Add(btnKatalog);
            pnlSidebar.Controls.Add(btnDataBuku);
            pnlSidebar.Controls.Add(lblAppName);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Margin = new Padding(2);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(210, 457);
            pnlSidebar.TabIndex = 0;
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAppName.Location = new Point(38, 35);
            lblAppName.Margin = new Padding(2, 0, 2, 0);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(131, 25);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "Panel sidebar";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FloralWhite;
            panel1.Controls.Add(btnBuatKatalog);
            panel1.Controls.Add(btnTambahBuku);
            panel1.Controls.Add(lblCompanyName);
            panel1.Controls.Add(lblPageTitle);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(210, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(759, 90);
            panel1.TabIndex = 1;
            // 
            // btnBuatKatalog
            // 
            btnBuatKatalog.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuatKatalog.BackColor = Color.Orange;
            btnBuatKatalog.Location = new Point(645, 49);
            btnBuatKatalog.Margin = new Padding(2);
            btnBuatKatalog.Name = "btnBuatKatalog";
            btnBuatKatalog.Size = new Size(105, 30);
            btnBuatKatalog.TabIndex = 3;
            btnBuatKatalog.Text = "Preview Katalog";
            btnBuatKatalog.UseVisualStyleBackColor = false;
            // 
            // btnTambahBuku
            // 
            btnTambahBuku.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTambahBuku.BackColor = Color.Yellow;
            btnTambahBuku.Location = new Point(536, 49);
            btnTambahBuku.Margin = new Padding(2);
            btnTambahBuku.Name = "btnTambahBuku";
            btnTambahBuku.Size = new Size(105, 30);
            btnTambahBuku.TabIndex = 2;
            btnTambahBuku.Text = "+ Tambah Buku";
            btnTambahBuku.UseVisualStyleBackColor = false;
            btnTambahBuku.Click += btnTambahBuku_Click;
            // 
            // lblCompanyName
            // 
            lblCompanyName.AutoSize = true;
            lblCompanyName.Location = new Point(18, 53);
            lblCompanyName.Margin = new Padding(2, 0, 2, 0);
            lblCompanyName.Name = "lblCompanyName";
            lblCompanyName.Size = new Size(76, 15);
            lblCompanyName.TabIndex = 1;
            lblCompanyName.Text = "Citra Persada";
            // 
            // lblPageTitle
            // 
            lblPageTitle.AutoSize = true;
            lblPageTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPageTitle.Location = new Point(18, 16);
            lblPageTitle.Margin = new Padding(2, 0, 2, 0);
            lblPageTitle.Name = "lblPageTitle";
            lblPageTitle.Size = new Size(278, 30);
            lblPageTitle.TabIndex = 0;
            lblPageTitle.Text = "Manajemen Katalog Buku";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(panelContent);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(210, 90);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(14, 12, 14, 12);
            panel2.Size = new Size(759, 367);
            panel2.TabIndex = 2;
            // 
            // panelContent
            // 
            panelContent.Controls.Add(panelTable);
            panelContent.Controls.Add(panelPreview);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(14, 72);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(731, 283);
            panelContent.TabIndex = 10;
            // 
            // panelTable
            // 
            panelTable.Controls.Add(dgvBuku);
            panelTable.Dock = DockStyle.Fill;
            panelTable.Location = new Point(0, 0);
            panelTable.Margin = new Padding(2);
            panelTable.Name = "panelTable";
            panelTable.Padding = new Padding(5);
            panelTable.Size = new Size(481, 283);
            panelTable.TabIndex = 10;
            // 
            // dgvBuku
            // 
            dgvBuku.AllowUserToAddRows = false;
            dgvBuku.AllowUserToDeleteRows = false;
            dgvBuku.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBuku.BackgroundColor = SystemColors.ControlLight;
            dgvBuku.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBuku.Dock = DockStyle.Fill;
            dgvBuku.Location = new Point(5, 5);
            dgvBuku.Margin = new Padding(2);
            dgvBuku.MultiSelect = false;
            dgvBuku.Name = "dgvBuku";
            dgvBuku.ReadOnly = true;
            dgvBuku.RowHeadersVisible = false;
            dgvBuku.RowHeadersWidth = 62;
            dgvBuku.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBuku.Size = new Size(471, 273);
            dgvBuku.TabIndex = 0;
            dgvBuku.CellContentClick += dgvBuku_CellContentClick;
            // 
            // panelPreview
            // 
            panelPreview.Controls.Add(picCover);
            panelPreview.Dock = DockStyle.Right;
            panelPreview.Location = new Point(481, 0);
            panelPreview.Name = "panelPreview";
            panelPreview.Size = new Size(250, 283);
            panelPreview.TabIndex = 11;
            panelPreview.Paint += panelPreview_Paint;
            // 
            // picCover
            // 
            picCover.BorderStyle = BorderStyle.FixedSingle;
            picCover.Dock = DockStyle.Fill;
            picCover.Location = new Point(0, 0);
            picCover.Name = "picCover";
            picCover.Padding = new Padding(5);
            picCover.Size = new Size(250, 283);
            picCover.SizeMode = PictureBoxSizeMode.Zoom;
            picCover.TabIndex = 0;
            picCover.TabStop = false;
            picCover.Click += picCover_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnResetFilter);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(txtCari);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(cmbJenjang);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(cmbKelas);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(cmbJenisBuku);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(14, 12);
            panel3.Margin = new Padding(2);
            panel3.Name = "panel3";
            panel3.Size = new Size(731, 60);
            panel3.TabIndex = 9;
            // 
            // btnResetFilter
            // 
            btnResetFilter.BackColor = Color.Tomato;
            btnResetFilter.Location = new Point(610, 24);
            btnResetFilter.Margin = new Padding(2);
            btnResetFilter.Name = "btnResetFilter";
            btnResetFilter.Size = new Size(78, 30);
            btnResetFilter.TabIndex = 4;
            btnResetFilter.Text = "Reset";
            btnResetFilter.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(475, 8);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(32, 15);
            label4.TabIndex = 8;
            label4.Text = "Jenis";
            // 
            // txtCari
            // 
            txtCari.Location = new Point(10, 32);
            txtCari.Margin = new Padding(2);
            txtCari.Name = "txtCari";
            txtCari.Size = new Size(171, 23);
            txtCari.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(344, 8);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 7;
            label3.Text = "Kelas";
            // 
            // cmbJenjang
            // 
            cmbJenjang.FormattingEnabled = true;
            cmbJenjang.Location = new Point(206, 31);
            cmbJenjang.Margin = new Padding(2);
            cmbJenjang.Name = "cmbJenjang";
            cmbJenjang.Size = new Size(99, 23);
            cmbJenjang.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(206, 8);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 6;
            label2.Text = "Jenjang";
            // 
            // cmbKelas
            // 
            cmbKelas.FormattingEnabled = true;
            cmbKelas.Location = new Point(340, 31);
            cmbKelas.Margin = new Padding(2);
            cmbKelas.Name = "cmbKelas";
            cmbKelas.Size = new Size(97, 23);
            cmbKelas.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 8);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(28, 15);
            label1.TabIndex = 5;
            label1.Text = "Cari";
            // 
            // cmbJenisBuku
            // 
            cmbJenisBuku.FormattingEnabled = true;
            cmbJenisBuku.Location = new Point(472, 31);
            cmbJenisBuku.Margin = new Padding(2);
            cmbJenisBuku.Name = "cmbJenisBuku";
            cmbJenisBuku.Size = new Size(105, 23);
            cmbJenisBuku.TabIndex = 3;
            // 
            // cmsBuku
            // 
            cmsBuku.Items.AddRange(new ToolStripItem[] { menuEditBuku, menuHapusBuku });
            cmsBuku.Name = "cmsBuku";
            cmsBuku.Size = new Size(139, 48);
            cmsBuku.Opening += cmsBuku_Opening;
            // 
            // menuEditBuku
            // 
            menuEditBuku.Name = "menuEditBuku";
            menuEditBuku.Size = new Size(138, 22);
            menuEditBuku.Text = "Edit Buku";
            menuEditBuku.Click += menuEditBuku_Click;
            // 
            // menuHapusBuku
            // 
            menuHapusBuku.Name = "menuHapusBuku";
            menuHapusBuku.Size = new Size(138, 22);
            menuHapusBuku.Text = "Hapus Buku";
            menuHapusBuku.Click += menuHapusBuku_Click;
            // 
            // btnDataBuku
            // 
            btnDataBuku.Location = new Point(9, 90);
            btnDataBuku.Margin = new Padding(2);
            btnDataBuku.Name = "btnDataBuku";
            btnDataBuku.Size = new Size(189, 30);
            btnDataBuku.TabIndex = 2;
            btnDataBuku.Text = "Data Buku";
            btnDataBuku.UseVisualStyleBackColor = true;
            // 
            // btnKatalog
            // 
            btnKatalog.Location = new Point(9, 131);
            btnKatalog.Margin = new Padding(2);
            btnKatalog.Name = "btnKatalog";
            btnKatalog.Size = new Size(189, 30);
            btnKatalog.TabIndex = 3;
            btnKatalog.Text = "Katalog";
            btnKatalog.UseVisualStyleBackColor = true;
            // 
            // btnPengaturan
            // 
            btnPengaturan.Location = new Point(9, 172);
            btnPengaturan.Margin = new Padding(2);
            btnPengaturan.Name = "btnPengaturan";
            btnPengaturan.Size = new Size(189, 30);
            btnPengaturan.TabIndex = 4;
            btnPengaturan.Text = "Pengaturan";
            btnPengaturan.UseVisualStyleBackColor = true;
            // 
            // FormDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(969, 457);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(pnlSidebar);
            Margin = new Padding(2);
            MinimumSize = new Size(985, 496);
            Name = "FormDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Citra Persada - Katalog Buku";
            WindowState = FormWindowState.Maximized;
            Load += FormDashboard_Load;
            pnlSidebar.ResumeLayout(false);
            pnlSidebar.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panelContent.ResumeLayout(false);
            panelTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBuku).EndInit();
            panelPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picCover).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            cmsBuku.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Panel panel1;
        private Panel panel2;
        private Label lblAppName;
        private Label lblCompanyName;
        private Label lblPageTitle;
        private Label label2;
        private Label label1;
        private Button btnResetFilter;
        private ComboBox cmbJenisBuku;
        private ComboBox cmbKelas;
        private ComboBox cmbJenjang;
        private TextBox txtCari;
        private Label label4;
        private Label label3;
        private Button btnBuatKatalog;
        private Button btnTambahBuku;
        private Panel panel3;
        private Panel panelTable;
        private DataGridView dgvBuku;
        private ContextMenuStrip cmsBuku;
        private ToolStripMenuItem menuEditBuku;
        private ToolStripMenuItem menuHapusBuku;
        private Panel panelPreview;
        private PictureBox picCover;
        private Panel panelContent;
        private Button btnPengaturan;
        private Button btnKatalog;
        private Button btnDataBuku;
    }
}