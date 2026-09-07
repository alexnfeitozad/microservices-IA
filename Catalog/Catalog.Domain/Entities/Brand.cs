namespace Catalog.Domain.Entities
{
    public class Brand
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;

        public Brand(string name)
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
                throw new ArgumentException("Brand name cannot be empty.", nameof(name));
            }
        }
    }
}
