using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace CitraPersadaCatalog.Data
{
    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            using var connection = Database.GetConnection();
            SeedSchoolClasses(connection);
            SeedSubjects(connection);
            using var command = connection.CreateCommand();

            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS education_levels (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    name TEXT NOT NULL UNIQUE
                );

                CREATE TABLE IF NOT EXISTS school_classes (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    level_id INTEGER NOT NULL,
                    name TEXT NOT NULL,
                    sort_order INTEGER NOT NULL DEFAULT 0,

                    FOREIGN KEY (level_id)
                        REFERENCES education_levels(id),

                    UNIQUE(level_id, name)
                );

                CREATE TABLE IF NOT EXISTS subjects (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    name TEXT NOT NULL,
                    category_type TEXT NOT NULL DEFAULT 'Mata Pelajaran',
                    is_active INTEGER NOT NULL DEFAULT 1,

                    UNIQUE(name, category_type)
                );

                CREATE TABLE IF NOT EXISTS books (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    level_id INTEGER NOT NULL,
                    class_id INTEGER NULL,
                    subject_id INTEGER NULL,

                    book_type TEXT NOT NULL CHECK (
                        book_type IN (
                            'Buku Siswa',
                            'Buku Panduan Guru'
                        )
                    ),

                    title TEXT NOT NULL,
                    selling_price INTEGER NULL CHECK (
                        selling_price IS NULL OR selling_price >= 0
                    ),

                    official_cover_url TEXT NULL,
                    cover_path TEXT NULL,
                    isbn TEXT NULL,

                    is_active INTEGER NOT NULL DEFAULT 1,
                    created_at TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
                    updated_at TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,

                    FOREIGN KEY (level_id)
                        REFERENCES education_levels(id),

                    FOREIGN KEY (class_id)
                        REFERENCES school_classes(id),

                    FOREIGN KEY (subject_id)
                        REFERENCES subjects(id)
                );

                CREATE INDEX IF NOT EXISTS idx_books_level
                    ON books(level_id);

                CREATE INDEX IF NOT EXISTS idx_books_class
                    ON books(class_id);

                CREATE INDEX IF NOT EXISTS idx_books_subject
                    ON books(subject_id);

                CREATE INDEX IF NOT EXISTS idx_books_title
                    ON books(title);
            ";

            command.ExecuteNonQuery();

            SeedEducationLevels(connection);
        }


        private static void SeedSubjects(SqliteConnection connection)
        {
            var subjects = new Dictionary<string, string[]>
            {
                ["Tema/Kategori"] = new[]
                {
                    "Jati Diri",
                    "Fase Fondasi",
                    "Dasar Literasi dan STEAM",
                    "Projek P5",
                    "Berbasis Buku",
                    "Agama dan Budi Pekerti"
                },

                ["Mata Pelajaran"] = new[]
                {
                    "Pendidikan Pancasila",
                    "Agama Islam",
                    "Agama Katolik",
                    "Agama Kristen",
                    "Seni Tari",
                    "Seni Rupa",
                    "Seni Musik",
                    "Seni Teater",
                    "Matematika",
                    "PJOK",
                    "Bahasa Indonesia"
                }
            };

            foreach (var category in subjects)
            {
                foreach (string subject in category.Value)
                {
                    using var command = connection.CreateCommand();

                    command.CommandText = @"
                        INSERT OR IGNORE INTO subjects
                            (name, category_type, is_active)
                        VALUES
                            ($name, $categoryType, 1);
                    ";

                    command.Parameters.AddWithValue("$name", subject);
                    command.Parameters.AddWithValue(
                        "$categoryType", category.Key);

                    command.ExecuteNonQuery();
                }
            }
        }


        private static void SeedEducationLevels(
            SqliteConnection connection)
        {
            string[] levels =
            {
                "PAUD",
                "SD/MI",
                "SMP/MTs",
                "SMA/MA",
                "SMK"
            };

            foreach (string level in levels)
            {
                using var command = connection.CreateCommand();

                command.CommandText = @"
                    INSERT OR IGNORE INTO education_levels (name)
                    VALUES ($name);
                ";

                command.Parameters.AddWithValue("$name", level);
                command.ExecuteNonQuery();
            }
        }

        private static void SeedSchoolClasses(SqliteConnection connection)
        {
            var classes = new Dictionary<string, string[]>
            {
                ["SD/MI"] = new[]
                {
                    "Kelas 1",
                    "Kelas 2",
                    "Kelas 3",
                    "Kelas 4",
                    "Kelas 5",
                    "Kelas 6"
                },

                ["SMP/MTs"] = new[]
                {
                    "Kelas VII",
                    "Kelas VIII",
                    "Kelas IX"
                },

                ["SMA/MA"] = new[]
                {
                    "Kelas X",
                    "Kelas XI",
                    "Kelas XII"
                },

                ["SMK"] = new[]
                {
                    "Kelas X",
                    "Kelas XI",
                    "Kelas XII"
                }
            };

            foreach (var level in classes)
            {
                using var getLevel = connection.CreateCommand();

                getLevel.CommandText = @"
                    SELECT id
                    FROM education_levels
                    WHERE name = $name;
                ";

                getLevel.Parameters.AddWithValue("$name", level.Key);

                var levelId = Convert.ToInt32(getLevel.ExecuteScalar());

                for (int i = 0; i < level.Value.Length; i++)
                {
                    using var insert = connection.CreateCommand();

                    insert.CommandText = @"
                        INSERT OR IGNORE INTO school_classes
                        (level_id, name, sort_order)
                        VALUES ($levelId, $name, $sortOrder);
                    ";

                    insert.Parameters.AddWithValue("$levelId", levelId);
                    insert.Parameters.AddWithValue("$name", level.Value[i]);
                    insert.Parameters.AddWithValue("$sortOrder", i + 1);

                    insert.ExecuteNonQuery();
                }
            }
        }
    }
}
