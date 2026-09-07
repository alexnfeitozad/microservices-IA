namespace Catalog.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public decimal Price { get; private set; }
        public string PictureFileName { get; private set; } = string.Empty;
        public int CatalogTypeId { get; private set; }
        public int CatalogBrandId { get; private set; }

        public Product(
            Guid id,
            string name,
            string description,
            decimal price,
            string pictureFileName,
            int catalogTypeId,
            int catalogBrandId)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Product ID cannot be empty.", nameof(id));
            }

            ValidateProduct(name, price, catalogTypeId, catalogBrandId);

            Id = id;
            Name = name;
            Description = description ?? string.Empty;
            Price = price;
            PictureFileName = pictureFileName ?? string.Empty;
            CatalogTypeId = catalogTypeId;
            CatalogBrandId = catalogBrandId;
        }

        private void ValidateProduct(string name, decimal price, int catalogTypeId, int catalogBrandId)
        {
            throw new NotImplementedException();
        }
        public Product(Guid id, string name, decimal price, string description,
         string pictureFileName, int catalogTypeId, int catalogBrandId)

        {
            ValidateProduct(name, price, catalogTypeId, catalogBrandId);

            Name = name;
            Description = description ?? string.Empty;
            Price = price;
            PictureFileName = pictureFileName ?? string.Empty;
            CatalogTypeId = catalogTypeId;
            CatalogBrandId = catalogBrandId;
        }
        public Product(string name, string description, decimal price, string pictureFileName, int catalogTypeId, int catalogBrandId)
        {
            ValidateName(name);
            ValidatePrice(price);
            ValidateDescription(description);
            ValidatePictureFileName(pictureFileName);
            ValidateCatalogTypeId(catalogTypeId);
            ValidateCatalogBrandId(catalogBrandId);

            Id = new Guid();
            Name = name;
            Price = price;
            Description = description;
            PictureFileName = pictureFileName;
            CatalogTypeId = catalogTypeId;
            CatalogBrandId = catalogBrandId;
        }

        private void ValidatePrice(decimal price)
        {
            if (price < 0)
            {
                throw new ArgumentException("Product price cannot be negative.");
            }
        }
        private void ValidateDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Product description cannot be empty.");
            }
        }
        private void ValidateCatalogTypeId(int catalogTypeId)
        {
            if (catalogTypeId <= 0)
            {
                throw new ArgumentException("Catalog type ID must be greater than zero.");
            }
        }
        private void ValidateCatalogBrandId(int catalogBrandId)
        {
            if (catalogBrandId <= 0)
            {
                throw new ArgumentException("Catalog brand ID must be greater than zero.");
            }
        }
        private void ValidatePictureFileName(string pictureFileName)
        {
            if (string.IsNullOrWhiteSpace(pictureFileName))
            {
                throw new ArgumentException("Product picture file name cannot be empty.");
            }
        }
        private void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Product name cannot be empty.");
            }
        }
        public void ValidateProduct(string name, decimal price, string description,
         string pictureFileName, int catalogTypeId, int catalogBrandId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Product name cannot be empty.", nameof(name));
            }

            if (price < 0)
            {
                throw new ArgumentException("Product price cannot be negative.", nameof(price));
            }

            if (catalogBrandId <= 0)
            {
                throw new ArgumentException("Catalog type ID must be greater than zero.", nameof(catalogTypeId));
            }

            if (catalogBrandId <= 0)
            {
                throw new ArgumentException("Catalog brand ID must be greater than zero.", nameof(catalogBrandId));
            }
        }
    }
}


