
using CitraPersadaCatalog.Data;
using CitraPersadaCatalog.Models;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace CitraPersadaCatalog.Repositories
{
    public class BookRepository
    {
        // Mengambil seluruh buku
        public List<Book> GetAll()
        {
            var books = new List<Book>();

            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                SELECT
                    b.id,
                    b.level_id,
                    b.class_id,
                    b.subject_id,
                    b.book_type,
                    b.title,
                    b.selling_price,
                    b.official_cover_url,
                    b.cover_path,
                    b.isbn,
                    b.is_active,
                    l.name AS level_name,
                    c.name AS class_name,
                    s.name AS subject_name

                FROM books b

                INNER JOIN education_levels l
                    ON b.level_id = l.id

                LEFT JOIN school_classes c
                    ON b.class_id = c.id

                LEFT JOIN subjects s
                    ON b.subject_id = s.id

                ORDER BY
                    l.id,
                    c.sort_order,
                    s.name,
                    b.title;
            ";

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                books.Add(MapBook(reader));
            }

            return books;
        }

        // Mengambil satu buku berdasarkan ID
        public Book? GetById(int id)
        {
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                SELECT
                    b.id,
                    b.level_id,
                    b.class_id,
                    b.subject_id,
                    b.book_type,
                    b.title,
                    b.selling_price,
                    b.official_cover_url,
                    b.cover_path,
                    b.isbn,
                    b.is_active,
                    l.name AS level_name,
                    c.name AS class_name,
                    s.name AS subject_name

                FROM books b

                INNER JOIN education_levels l
                    ON b.level_id = l.id

                LEFT JOIN school_classes c
                    ON b.class_id = c.id

                LEFT JOIN subjects s
                    ON b.subject_id = s.id

                WHERE b.id = $id;
            ";

            command.Parameters.AddWithValue("$id", id);

            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return MapBook(reader);
            }

            return null;
        }

        // Menambahkan buku
        public int Insert(Book book)
        {
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                INSERT INTO books (
                    level_id,
                    class_id,
                    subject_id,
                    book_type,
                    title,
                    selling_price,
                    official_cover_url,
                    cover_path,
                    isbn,
                    is_active
                )
                VALUES (
                    $levelId,
                    $classId,
                    $subjectId,
                    $bookType,
                    $title,
                    $sellingPrice,
                    $officialCoverUrl,
                    $coverPath,
                    $isbn,
                    $isActive
                );

                SELECT last_insert_rowid();
            ";

            AddBookParameters(command, book);

            return System.Convert.ToInt32(command.ExecuteScalar());
        }

        // Mengubah data buku
        public bool Update(Book book)
        {
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                UPDATE books SET
                    level_id = $levelId,
                    class_id = $classId,
                    subject_id = $subjectId,
                    book_type = $bookType,
                    title = $title,
                    selling_price = $sellingPrice,
                    official_cover_url = $officialCoverUrl,
                    cover_path = $coverPath,
                    isbn = $isbn,
                    is_active = $isActive,
                    updated_at = CURRENT_TIMESTAMP

                WHERE id = $id;
            ";

            AddBookParameters(command, book);
            command.Parameters.AddWithValue("$id", book.Id);

            return command.ExecuteNonQuery() > 0;
        }

        // Menghapus buku
        public bool Delete(int id)
        {
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                DELETE FROM books
                WHERE id = $id;
            ";

            command.Parameters.AddWithValue("$id", id);

            return command.ExecuteNonQuery() > 0;
        }

        // Mengatur parameter INSERT dan UPDATE
        private static void AddBookParameters(
            SqliteCommand command,
            Book book)
        {
            command.Parameters.AddWithValue(
                "$levelId", book.LevelId);

            command.Parameters.AddWithValue(
                "$classId",
                (object?)book.ClassId ?? System.DBNull.Value);

            command.Parameters.AddWithValue(
                "$subjectId",
                (object?)book.SubjectId ?? System.DBNull.Value);

            command.Parameters.AddWithValue(
                "$bookType", book.BookType);

            command.Parameters.AddWithValue(
                "$title", book.Title);

            command.Parameters.AddWithValue(
                "$sellingPrice",
                (object?)book.SellingPrice ?? System.DBNull.Value);

            command.Parameters.AddWithValue(
                "$officialCoverUrl",
                (object?)book.OfficialCoverUrl ?? System.DBNull.Value);

            command.Parameters.AddWithValue(
                "$coverPath",
                (object?)book.CoverPath ?? System.DBNull.Value);

            command.Parameters.AddWithValue(
                "$isbn",
                (object?)book.ISBN ?? System.DBNull.Value);

            command.Parameters.AddWithValue(
                "$isActive", book.IsActive ? 1 : 0);
        }

        // Mengubah hasil query menjadi object Book
        private static Book MapBook(SqliteDataReader reader)
        {
            return new Book
            {
                Id = reader.GetInt32(reader.GetOrdinal("id")),

                LevelId = reader.GetInt32(
                    reader.GetOrdinal("level_id")),

                ClassId = reader.IsDBNull(
                    reader.GetOrdinal("class_id"))
                    ? null
                    : reader.GetInt32(reader.GetOrdinal("class_id")),

                SubjectId = reader.IsDBNull(
                    reader.GetOrdinal("subject_id"))
                    ? null
                    : reader.GetInt32(reader.GetOrdinal("subject_id")),

                BookType = reader.GetString(
                    reader.GetOrdinal("book_type")),

                Title = reader.GetString(
                    reader.GetOrdinal("title")),

                SellingPrice = reader.IsDBNull(
                    reader.GetOrdinal("selling_price"))
                    ? null
                    : reader.GetInt64(
                        reader.GetOrdinal("selling_price")),

                OfficialCoverUrl = reader.IsDBNull(
                    reader.GetOrdinal("official_cover_url"))
                    ? null
                    : reader.GetString(
                        reader.GetOrdinal("official_cover_url")),

                CoverPath = reader.IsDBNull(
                    reader.GetOrdinal("cover_path"))
                    ? null
                    : reader.GetString(
                        reader.GetOrdinal("cover_path")),

                ISBN = reader.IsDBNull(
                    reader.GetOrdinal("isbn"))
                    ? null
                    : reader.GetString(
                        reader.GetOrdinal("isbn")),

                IsActive = reader.GetInt32(
                    reader.GetOrdinal("is_active")) == 1,

                LevelName = reader.GetString(
                    reader.GetOrdinal("level_name")),

                ClassName = reader.IsDBNull(
                    reader.GetOrdinal("class_name"))
                    ? null
                    : reader.GetString(
                        reader.GetOrdinal("class_name")),

                SubjectName = reader.IsDBNull(
                    reader.GetOrdinal("subject_name"))
                    ? null
                    : reader.GetString(
                        reader.GetOrdinal("subject_name"))
            };
        }
    }
}
