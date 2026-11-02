
using CitraPersadaCatalog.Data;
using CitraPersadaCatalog.Models;
using System.Collections.Generic;

namespace CitraPersadaCatalog.Repositories
{
    public class CatalogRepository
    {
        // Mengambil daftar jenjang pendidikan
        public List<CatalogItem> GetLevels()
        {
            var items = new List<CatalogItem>();

            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                SELECT id, name
                FROM education_levels
                ORDER BY id;
            ";

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                items.Add(new CatalogItem
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                });
            }

            return items;
        }

        // Mengambil kelas berdasarkan jenjang
        public List<CatalogItem> GetClasses(int levelId)
        {
            var items = new List<CatalogItem>();

            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                SELECT id, name
                FROM school_classes
                WHERE level_id = $levelId
                ORDER BY sort_order;
            ";

            command.Parameters.AddWithValue("$levelId", levelId);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                items.Add(new CatalogItem
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                });
            }

            return items;
        }

        // Mengambil mata pelajaran atau tema berdasarkan jenis kategori
        public List<CatalogItem> GetSubjects(string categoryType)
        {
            var items = new List<CatalogItem>();

            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                SELECT id, name
                FROM subjects
                WHERE category_type = $categoryType
                  AND is_active = 1
                ORDER BY name;
            ";

            command.Parameters.AddWithValue(
                "$categoryType", categoryType);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                items.Add(new CatalogItem
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                });
            }

            return items;
        }
    }
}
