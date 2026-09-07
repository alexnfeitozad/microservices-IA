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

        //regras de negocio Domain
        // Exemplo: Validar que o nome do produto não esteja vazio
        #region Validation Methods
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
        // Exemplo: Validar que o nome do produto não esteja vazio
        public void ValidateProduct(string name, decimal price, string description,
         string pictureFileName, int catalogTypeId, int catalogBrandId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Product name cannot be empty.");
            }

            if (price < 0)
            {
                throw new ArgumentException("Product price cannot be negative.");
            }

            if (catalogBrandId <= 0)
            {
                throw new ArgumentException("Catalog type ID must be greater than zero.");
            }

            if (catalogBrandId <= 0)
            {
                throw new ArgumentException("Catalog brand ID must be greater than zero.");
            }
        }
    }
    #endregion validation Methods
}