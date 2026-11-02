using CitraPersadaCatalog.Data;
using CitraPersadaCatalog.Models;
using CitraPersadaCatalog.Repositories;
using CitraPersadaCatalog.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace CitraPersadaCatalog.Forms
{
    public partial class FormBookInput : Form
    {
        private readonly CatalogRepository _catalogRepository =
        new CatalogRepository();

        private readonly BookRepository _bookRepository =
        new BookRepository();

        private readonly CoverService _coverService =
        new CoverService();

        private int? _bookId;
        private string? _oldCoverPath;

        private bool IsEditMode => _bookId.HasValue;

        public FormBookInput(int bookId) : this()
        {
            _bookId = bookId;

            LoadBookForEdit(bookId);

            btnSimpan.Text = "Simpan Perubahan";
            lblTitle.Text = "Edit Buku";
        }
        private void LoadBookForEdit(int bookId)
        {
            Book? book = _bookRepository.GetById(bookId);

            if (book == null)
            {
                MessageBox.Show("Data buku tidak ditemukan.");
                this.Close();
                return;
            }

            _oldCoverPath = book.CoverPath;

            // Pilih jenjang
            cmbJenjang.SelectedValue = book.LevelId;

            // Muat ulang kelas dan mata pelajaran
            CatalogItem? selectedLevel =
                cmbJenjang.SelectedItem as CatalogItem;

            if (selectedLevel == null)
                return;

            bool isPAUD = selectedLevel.Name == "PAUD";

            cmbKelas.Enabled = !isPAUD;

            if (!isPAUD)
            {
                cmbKelas.DataSource =
                    _catalogRepository.GetClasses(book.LevelId);

                cmbKelas.DisplayMember = "Name";
                cmbKelas.ValueMember = "Id";
                cmbKelas.SelectedValue = book.ClassId;
            }

            string categoryType = isPAUD
                ? "Tema/Kategori"
                : "Mata Pelajaran";

            cmbMataPelajaran.DataSource =
                _catalogRepository.GetSubjects(categoryType);

            cmbMataPelajaran.DisplayMember = "Name";
            cmbMataPelajaran.ValueMember = "Id";
            cmbMataPelajaran.SelectedValue = book.SubjectId;

            cmbMataPelajaran.Text = isPAUD
                ? "Tema / Kategori"
                : "Mata Pelajaran";

            cmbJenisBuku.SelectedItem = book.BookType;

            txtJudulBuku.Text = book.Title;

            txtHargaJual.Text = book.SellingPrice?.ToString("N0") ?? "";

            txtCoverPath.Text = book.CoverPath ?? "";
        }

        public FormBookInput()
        {
            InitializeComponent();
            cmbJenjang.SelectedIndexChanged += cmbJenjang_SelectedIndexChanged;

            LoadLevels();
            LoadBookTypes();
        }
        private void LoadLevels()
        {
            cmbJenjang.DataSource = _catalogRepository.GetLevels();
            cmbJenjang.DisplayMember = "Name";
            cmbJenjang.ValueMember = "Id";
            cmbJenjang.SelectedIndex = -1;
        }
        private void LoadBookTypes()
        {
            cmbJenisBuku.Items.Clear();

            cmbJenisBuku.Items.Add("Buku Siswa");
            cmbJenisBuku.Items.Add("Buku Panduan Guru");

            cmbJenisBuku.SelectedIndex = -1;
        }
        private void cmbJenjang_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbJenjang.SelectedItem is not CatalogItem selectedLevel)
                return;

            bool isPAUD = selectedLevel.Name == "PAUD";

            // Kelas
            cmbKelas.DataSource = null;
            cmbKelas.Items.Clear();

            cmbKelas.Enabled = !isPAUD;

            if (!isPAUD)
            {
                cmbKelas.DataSource =
                    _catalogRepository.GetClasses(selectedLevel.Id);

                cmbKelas.DisplayMember = "Name";
                cmbKelas.ValueMember = "Id";
                cmbKelas.SelectedIndex = -1;
            }

            // Mata pelajaran atau tema
            cmbMataPelajaran.DataSource = null;

            string categoryType = isPAUD
                ? "Tema/Kategori"
                : "Mata Pelajaran";

            cmbMataPelajaran.DataSource =
                _catalogRepository.GetSubjects(categoryType);

            cmbMataPelajaran.DisplayMember = "Name";
            cmbMataPelajaran.ValueMember = "Id";
            cmbMataPelajaran.SelectedIndex = -1;

            // Ubah label kategori
            cmbMataPelajaran.Text = isPAUD
                ? "Tema / Kategori"
                : "Mata Pelajaran";
        }


        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // Validasi jenjang
            if (cmbJenjang.SelectedItem is not CatalogItem selectedLevel)
            {
                MessageBox.Show("Pilih jenjang pendidikan.");
                cmbJenjang.Focus();
                return;
            }

            // Validasi kelas (PAUD tidak wajib)
            bool isPAUD = selectedLevel.Name == "PAUD";

            CatalogItem? selectedClass =
                cmbKelas.SelectedItem as CatalogItem;

            if (!isPAUD && selectedClass == null)
            {
                MessageBox.Show("Pilih kelas.");
                cmbKelas.Focus();
                return;
            }

            // Validasi mata pelajaran / tema
            if (cmbMataPelajaran.SelectedItem is not CatalogItem selectedSubject)
            {
                MessageBox.Show("Pilih mata pelajaran atau tema.");
                cmbMataPelajaran.Focus();
                return;
            }

            // Validasi jenis buku
            if (cmbJenisBuku.SelectedItem == null)
            {
                MessageBox.Show("Pilih jenis buku.");
                cmbJenisBuku.Focus();
                return;
            }

            // Validasi judul
            string title = txtJudulBuku.Text.Trim();

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Judul buku wajib diisi.");
                txtJudulBuku.Focus();
                return;
            }

            // Validasi harga (boleh kosong)
            long? sellingPrice = null;

            string priceText = txtHargaJual.Text.Trim();

            if (!string.IsNullOrWhiteSpace(priceText))
            {
                string digits = new string(
                    priceText.Where(char.IsDigit).ToArray());

                if (!long.TryParse(digits, out long parsedPrice))
                {
                    MessageBox.Show("Harga jual tidak valid.");
                    txtHargaJual.Focus();
                    return;
                }

                sellingPrice = parsedPrice;
            }

            string? newCoverPath = null;

            try
            {
                // Pertahankan cover lama
                string? savedCoverPath = _oldCoverPath;

                string coverInput = txtCoverPath.Text.Trim();

                // Salin hanya jika memilih cover baru
                if (!string.IsNullOrWhiteSpace(coverInput) &&
                    !string.Equals(
                        coverInput,
                        _oldCoverPath,
                        StringComparison.OrdinalIgnoreCase))
                {
                    newCoverPath = _coverService.SaveCover(coverInput);
                    savedCoverPath = newCoverPath;
                }

                Book book = new Book
                {
                    Id = _bookId ?? 0,
                    LevelId = selectedLevel.Id,
                    ClassId = isPAUD ? null : selectedClass!.Id,
                    SubjectId = selectedSubject.Id,
                    BookType = cmbJenisBuku.Text,
                    Title = title,
                    SellingPrice = sellingPrice,
                    CoverPath = savedCoverPath,
                    IsActive = true
                };

                if (IsEditMode)
                {
                    _bookRepository.Update(book);
                }
                else
                {
                    _bookRepository.Insert(book);
                }

                MessageBox.Show(
                    IsEditMode
                        ? "Buku berhasil diperbarui!"
                        : "Buku berhasil disimpan!",
                    "Berhasil",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // Hapus hanya cover BARU jika penyimpanan gagal
                if (newCoverPath != null)
                {
                    string fullPath = Path.Combine(
                        Path.GetDirectoryName(Database.DatabasePath)!,
                        newCoverPath.Replace(
                            '/', Path.DirectorySeparatorChar));

                    if (File.Exists(fullPath))
                        File.Delete(fullPath);
                }

                MessageBox.Show(
                    "Gagal menyimpan buku:\n" + ex.Message,
                    "Kesalahan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnPilihCover_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Pilih Cover Buku";
            dialog.Filter = "File Gambar|*.jpg;*.jpeg;*.png;*.webp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtCoverPath.Text = dialog.FileName;
            }
        }
    }
}
