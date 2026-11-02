
namespace CitraPersadaCatalog.Models
{
    public class CatalogItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public override string ToString()
        {
            return Name;
        }
    }
}
