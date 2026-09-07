
using Catalog.Domain.Entities;

namespace Catalog.UnitTests.Entities
{
    public class BrandTests
    {
        [Fact]
        public void Should_Create_Brand_With_Valid_Data()
        {
            var brand = new Brand(1, "Test Brand");

            Assert.NotNull(brand);
            Assert.Equal(1, brand.Id);
            Assert.Equal("Test Brand", brand.Name);
        }

        [Fact]
        public void Should_Reject_Non_Positive_Brand_Id()
        {
            Assert.Throws<ArgumentException>(() => new Brand(0, "Test Brand"));
            Assert.Throws<ArgumentException>(() => new Brand(-1, "Test Brand"));
        }
    }
}