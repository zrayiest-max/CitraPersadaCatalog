
using Microsoft.Data.Sqlite;
using System;
using System.IO;

namespace CitraPersadaCatalog.Data
{
    public static class Database
    {
        private static readonly string AppFolder =
            Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "CitraPersada",
                "Catalog"
            );

        public static readonly string DatabasePath =
            Path.Combine(AppFolder, "catalog.db");

        public static SqliteConnection GetConnection()
        {
            Directory.CreateDirectory(AppFolder);

            var connection = new SqliteConnection(
                $"Data Source={DatabasePath}"
            );

            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "PRAGMA foreign_keys = ON;";
            command.ExecuteNonQuery();

            return connection;
        }
    }
}
