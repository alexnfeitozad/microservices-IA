using Catalog.Domain.Entities;

namespace Catalog.UnitTests.Entities;

public class CatalogTypeTests
{
    [Fact]
    public void Constructor_WithValidData_AssignsIdentityAndName()
    {
        var catalogType = new CatalogType(1, "Test Catalog Type");

        Assert.Equal(1, catalogType.Id);
        Assert.Equal("Test Catalog Type", catalogType.Name);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Constructor_WithNonPositiveId_ThrowsArgumentException(int id)
    {
        var exception = Assert.Throws<ArgumentException>(() => new CatalogType(id, "Test Catalog Type"));

        Assert.Equal("id", exception.ParamName);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_WithInvalidName_ThrowsArgumentException(string? name)
    {
        var exception = Assert.Throws<ArgumentException>(() => new CatalogType(1, name!));

        Assert.Equal("name", exception.ParamName);
    }
}
