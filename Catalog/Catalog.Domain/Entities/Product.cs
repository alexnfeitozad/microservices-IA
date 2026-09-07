using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public decimal Price { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public string PictureFileName { get; private set; } = string.Empty;
        public int CatalogTypeId { get; private set; }
        public int CatalogBrandId { get; private set; }


        public Product(Guid id, string name, decimal price, string description,
         string pictureFileName, int catalogTypeId, int catalogBrandId)
        {
            ValidateProduct(name, price, description, pictureFileName, catalogTypeId, catalogBrandId);

            Id = new Guid();
            Name = name;
            Price = price;
            Description = description;
            PictureFileName = pictureFileName;
            CatalogTypeId = catalogTypeId;
            CatalogBrandId = catalogBrandId;
        }

        //regras de negocio Domain
        // Exemplo: Validar que o nome do produto não esteja vazio
        private void ValidateProduct(string name, decimal price, string description, string pictureFileName, int catalogTypeId, int catalogBrandId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Product name cannot be empty.");
            }

            if (price < 0)
            {
                throw new ArgumentException("Product price cannot be negative.");
            }

            if (catalogTypeId <= 0)
            {
                throw new ArgumentException("Catalog type ID must be greater than zero.");
            }

            if (catalogBrandId <= 0)
            {
                throw new ArgumentException("Catalog brand ID must be greater than zero.");
            }
        }
    }
}