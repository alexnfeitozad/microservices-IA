using Catalog.Domain.Entities;

namespace Catalog.UnitTests.Entities;

public class BrandTests
{
    [Fact]
    public void Constructor_WithValidName_AssignsName()
    {
        var brand = new Brand("Nike");

        Assert.Equal("Nike", brand.Name);
        Assert.Equal(0, brand.Id);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_WithInvalidName_ThrowsArgumentException(string? name)
    {
        var exception = Assert.Throws<ArgumentException>(() => new Brand(name!));

        Assert.Equal("name", exception.ParamName);
    }

    [Fact]
    public void UpdateName_WithValidName_ChangesName()
    {
        var brand = new Brand("Nike");

        brand.UpdateName("Adidas");

        Assert.Equal("Adidas", brand.Name);
    }

    [Fact]
    public void UpdateName_WithInvalidName_KeepsPreviousName()
    {
        var brand = new Brand("Nike");

        Assert.Throws<ArgumentException>(() => brand.UpdateName(" "));

        Assert.Equal("Nike", brand.Name);
    }
}
