using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Domain.Entities
{
    public class CatalogType
    {
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