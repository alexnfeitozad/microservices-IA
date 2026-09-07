
using Catalog.Domain.Entities;

namespace Catalog.UnitTests.Entities
{
    public class CatalogTypeTests
    {
        [Fact]
        public void Should_Create_CatalogType_With_Valid_Data()
        {
            var catalogType = new CatalogType(1, "Test Catalog Type");

            Assert.NotNull(catalogType);
            Assert.Equal(1, catalogType.Id);
            Assert.Equal("Test Catalog Type", catalogType.Name);
        }

        [Fact]
        public void Should_Reject_Non_Positive_CatalogType_Id()
        {
            Assert.Throws<ArgumentException>(() => new CatalogType(0, "Test Catalog Type"));
            Assert.Throws<ArgumentException>(() => new CatalogType(-1, "Test Catalog Type"));
        }
    }
}