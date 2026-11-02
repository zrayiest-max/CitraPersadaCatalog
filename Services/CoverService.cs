
using CitraPersadaCatalog.Data;
using System;
using System.IO;

namespace CitraPersadaCatalog.Services
{
    public class CoverService
    {
        public string SaveCover(string sourcePath)
        {
            if (string.IsNullOrWhiteSpace(sourcePath) ||
                !File.Exists(sourcePath))
            {
                throw new FileNotFoundException(
                    "File cover tidak ditemukan.");
            }

            string extension = Path.GetExtension(sourcePath).ToLowerInvariant();

            string[] allowedExtensions =
            {
                ".jpg", ".jpeg", ".png", ".webp"
            };

            if (!Array.Exists(
                allowedExtensions,
                ext => ext == extension))
            {
                throw new InvalidOperationException(
                    "Format gambar tidak didukung.");
            }

            string coverFolder = Path.Combine(
                Path.GetDirectoryName(Database.DatabasePath)!,
                "Covers"
            );

            Directory.CreateDirectory(coverFolder);

            string fileName = $"{Guid.NewGuid()}{extension}";

            string destinationPath = Path.Combine(
                coverFolder,
                fileName
            );

            File.Copy(sourcePath, destinationPath);

            // Simpan path relatif ke database
            return Path.Combine("Covers", fileName)
                .Replace("\\", "/");
        }
    }
}
