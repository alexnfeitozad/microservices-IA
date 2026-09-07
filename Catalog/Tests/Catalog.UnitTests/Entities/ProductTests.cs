using Catalog.Domain.Entities;

namespace Catalog.UnitTests.Entities
{
    public class ProductTests
    {
        [Fact]
        public void Should_Create_Product_With_Valid_Data()
        {
            var product = new Product("Notebook", "Test Description", 3500m, "notebook.jpg", 1, 1);

            Assert.NotNull(product);
            Assert.Equal("Notebook", product.Name);
            Assert.Equal("Test Description", product.Description);
            Assert.Equal("notebook.jpg", product.PictureFileName);
            Assert.Equal(3500m, product.Price);
            Assert.Equal(1, product.CatalogBrandId);
            Assert.Equal(1, product.CatalogTypeId);
        }
        [Fact]
        public void Should_Reject_Negative_Price()
        {
            Assert.Throws<ArgumentException>(() => new Product("Notebook", "Test Description", -3500m, "notebook.jpg", 1, 1));
        }
        [Fact]
        public void Should_Reject_Empty_Product_Name()
        {
            Assert.Throws<ArgumentException>(() => new Product("", "Test Description", 3500m, "notebook.jpg", 1, 1));
        }

    }
}