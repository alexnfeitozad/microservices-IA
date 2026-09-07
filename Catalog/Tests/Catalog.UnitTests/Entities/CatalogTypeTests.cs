using Catalog.Domain.Entities;

namespace Catalog.UnitTests.Entities;

public class CatalogTypeTests
{
    [Fact]
    public void Constructor_WithValidName_AssignsName()
    {
        var catalogType = new CatalogType("Shoes");

        Assert.Equal("Shoes", catalogType.Name);
        Assert.Equal(0, catalogType.Id);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_WithInvalidName_ThrowsArgumentException(string? name)
    {
        var exception = Assert.Throws<ArgumentException>(() => new CatalogType(name!));

        Assert.Equal("name", exception.ParamName);
    }

    [Fact]
    public void UpdateName_WithValidName_ChangesName()
    {
        var catalogType = new CatalogType("Shoes");

        catalogType.UpdateName("Apparel");

        Assert.Equal("Apparel", catalogType.Name);
    }

    [Fact]
    public void UpdateName_WithInvalidName_KeepsPreviousName()
    {
        var catalogType = new CatalogType("Shoes");

        Assert.Throws<ArgumentException>(() => catalogType.UpdateName(" "));

        Assert.Equal("Shoes", catalogType.Name);
    }
}
