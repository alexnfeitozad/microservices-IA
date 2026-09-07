
namespace Catalog.Domain.Entities
{
    public class CatalogType
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;

        public CatalogType(int id, string name)
        {
            if (id <= 0)
            {
                throw new ArgumentException("CatalogType ID must be greater than zero.", nameof(id));
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("CatalogType name cannot be empty.", nameof(name));
            }

            Id = id;
            Name = name;
        }
    }
}

