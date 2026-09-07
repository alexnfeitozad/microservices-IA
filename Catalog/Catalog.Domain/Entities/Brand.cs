

namespace Catalog.Domain.Entities
{
    public class Brand
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;

        public Brand(int id, string name)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Brand ID must be greater than zero.", nameof(id));
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Brand name cannot be empty.", nameof(name));
            }

            Id = id;
            Name = name;
        }

    }
}
