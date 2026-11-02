using CitraPersadaCatalog.Data;
using CitraPersadaCatalog.Forms;
using CitraPersadaCatalog.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace CitraPersadaCatalog.Forms
{
    public partial class FormDashboard : Form
    {
        private readonly BookRepository _bookRepository = new BookRepository();

        public FormDashboard()
        {
            InitializeComponent();
            dgvBuku.CellMouseDown += dgvBuku_CellMouseDown;
            dgvBuku.SelectionChanged += dgvBuku_SelectionChanged;
        }

        private void dgvBuku_SelectionChanged(object? sender, EventArgs e)
        {
            picCover.Image = null;

            if (dgvBuku.SelectedRows.Count == 0)
                return;

            string? coverPath = dgvBuku.SelectedRows[0]
                .Cells["CoverPath"].Value?.ToString();

            if (string.IsNullOrWhiteSpace(coverPath))
                return;

            string fullPath = Path.Combine(
                Path.GetDirectoryName(Database.DatabasePath)!,
                coverPath.Replace('/', Path.DirectorySeparatorChar)
            );

            if (File.Exists(fullPath))
            {
                using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                {
                    using (var tempImage = Image.FromStream(stream))
                    {
                        picCover.Image = new Bitmap(tempImage);
                    }
                }
            }
        }

        private void dgvBuku_CellMouseDown(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvBuku.ClearSelection();

                DataGridViewRow row = dgvBuku.Rows[e.RowIndex];
                row.Selected = true;

                // Cari kolom pertama yang terlihat
                DataGridViewColumn? visibleColumn =
                    dgvBuku.Columns
                        .Cast<DataGridViewColumn>()
                        .FirstOrDefault(c => c.Visible);

                if (visibleColumn != null)
                {
                    dgvBuku.CurrentCell = row.Cells[visibleColumn.Index];
                }

                cmsBuku.Show(Cursor.Position);
            }
        }

        private void menuEditBuku_Click(object? sender, EventArgs e)
        {
            if (dgvBuku.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih buku yang ingin diedit.");
                return;
            }

            int bookId = Convert.ToInt32(
                dgvBuku.SelectedRows[0].Cells["Id"].Value
            );

            using (FormBookInput form = new FormBookInput(bookId))
            {
                DialogResult result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    LoadBooks();
                }
            }
        }

        private void menuHapusBuku_Click(object? sender, EventArgs e)
        {
            if (dgvBuku.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih buku yang ingin dihapus.");
                return;
            }

            int bookId = Convert.ToInt32(
                dgvBuku.SelectedRows[0].Cells["Id"].Value
            );

            string judul = dgvBuku.SelectedRows[0]
                .Cells["Title"].Value?.ToString() ?? "";

            DialogResult result = MessageBox.Show(
                $"Yakin ingin menghapus buku:\n\n{judul}?",
                "Konfirmasi Hapus",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    _bookRepository.Delete(bookId);

                    LoadBooks();

                    MessageBox.Show("Buku berhasil dihapus.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Gagal menghapus buku:\n" + ex.Message,
                        "Kesalahan",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            LoadBooks();
        }


        private void LoadBooks()
        {
            var books = _bookRepository.GetAll();

            dgvBuku.AutoGenerateColumns = true;
            dgvBuku.DataSource = null;
            dgvBuku.DataSource = books;

            // Sembunyikan kolom ID
            dgvBuku.Columns["Id"].Visible = false;
            dgvBuku.Columns["LevelId"].Visible = false;
            dgvBuku.Columns["ClassId"].Visible = false;
            dgvBuku.Columns["SubjectId"].Visible = false;
            dgvBuku.Columns["OfficialCoverUrl"].Visible = false;
            dgvBuku.Columns["CoverPath"].Visible = false;
            dgvBuku.Columns["IsActive"].Visible = false;
            dgvBuku.Columns["ISBN"].Visible = false;

            // Ubah judul kolom
            dgvBuku.Columns["Title"].HeaderText = "Judul Buku";
            dgvBuku.Columns["LevelName"].HeaderText = "Jenjang";
            dgvBuku.Columns["ClassName"].HeaderText = "Kelas";
            dgvBuku.Columns["SubjectName"].HeaderText = "Mata Pelajaran / Tema";
            dgvBuku.Columns["BookType"].HeaderText = "Jenis Buku";
            dgvBuku.Columns["SellingPrice"].HeaderText = "Harga Jual";

            // Format harga
            dgvBuku.Columns["SellingPrice"].DefaultCellStyle.Format = "N0";
            dgvBuku.Columns["SellingPrice"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            // Tampilan tabel
            dgvBuku.ReadOnly = true;
            dgvBuku.AllowUserToAddRows = false;
            dgvBuku.AllowUserToDeleteRows = false;
            dgvBuku.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvBuku.MultiSelect = false;
            dgvBuku.RowHeadersVisible = false;
        }

        private void btnTambahBuku_Click(object sender, EventArgs e)
        {
            using (FormBookInput form = new FormBookInput())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadBooks();
                }
            }
        }

        private void cmsBuku_Opening(object sender, CancelEventArgs e)
        {

        }

        private void panelPreview_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvBuku_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void picCover_Click(object sender, EventArgs e)
        {

        }
    }
}
