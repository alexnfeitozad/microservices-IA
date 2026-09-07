
namespace Catalog.Domain.Entities
{
    public class CatalogType
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;

        public CatalogType(string name)
        {
            ValidateName(name);
            Name = name;
        }

        public void UpdateName(string name)
        {
            ValidateName(name);
            Name = name;
        }

        private static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Catalog type name cannot be empty.", nameof(name));
            }
        }
    }
}
        public Guid Id { get; set; }
        public string Name { get; private set; } = string.Empty;

        protected CatalogType() { }

        public CatalogType(string name)
        {
            Id = Guid.NewGuid();
            SetName(name);
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Catalog type name cannot be empty.");
            }
            if (name.Length > 100)
            {
                throw new ArgumentException("Catalog type name cannot exceed 100 characters.");
            }
            Name = name;
        }
    }
}

