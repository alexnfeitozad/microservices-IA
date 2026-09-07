using Catalog.Domain.Entities;

namespace Catalog.UnitTests.Entities;

public class BrandTests
{
    [Fact]
    public void Constructor_WithValidData_AssignsIdentityAndName()
    {
        var brand = new Brand(1, "Test Brand");

        Assert.Equal(1, brand.Id);
        Assert.Equal("Test Brand", brand.Name);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Constructor_WithNonPositiveId_ThrowsArgumentException(int id)
    {
        var exception = Assert.Throws<ArgumentException>(() => new Brand(id, "Test Brand"));

        Assert.Equal("id", exception.ParamName);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_WithInvalidName_ThrowsArgumentException(string? name)
    {
        var exception = Assert.Throws<ArgumentException>(() => new Brand(1, name!));

        Assert.Equal("name", exception.ParamName);
    }
}
