
namespace CitraPersadaCatalog.Models
{
    public class Book
    {
        public int Id { get; set; }

        public int LevelId { get; set; }
        public int? ClassId { get; set; }
        public int? SubjectId { get; set; }

        public string BookType { get; set; } = "Buku Siswa";

        public string Title { get; set; } = string.Empty;

        public long? SellingPrice { get; set; }

        public string? OfficialCoverUrl { get; set; }
        public string? CoverPath { get; set; }
        public string? ISBN { get; set; }

        public bool IsActive { get; set; } = true;

        // Informasi tambahan untuk tampilan
        public string? LevelName { get; set; }
        public string? ClassName { get; set; }
        public string? SubjectName { get; set; }
    }
}
