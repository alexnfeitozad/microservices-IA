
namespace Catalog.Domain.Entities
{
    public class Brand
    {
        public Guid Id { get; set; }
        public string Name { get; private set; } = string.Empty;

        protected Brand() { }

        public Brand(string name)
        {
            Id = Guid.NewGuid();
            SetName(name);
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Brand name cannot be empty.");
            }
            if (name.Length > 100)
            {
                throw new ArgumentException("Brand name cannot exceed 100 characters.");
            }
            Name = name;
        }
    }
}