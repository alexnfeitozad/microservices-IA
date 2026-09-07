using Catalog.Domain.Entities;

namespace Catalog.UnitTests.Entities;

public class ProductTests
{
    private static readonly Guid ValidId = Guid.Parse("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");

    private static Product CreateValidProduct() =>
        new(ValidId, "Running Shoes", "Lightweight trainers", 199.90m, "shoes.png", 1, 2);

    [Fact]
    public void Constructor_WithValidData_AssignsIdentityAndState()
    {
        var product = CreateValidProduct();

        Assert.Equal(ValidId, product.Id);
        Assert.Equal("Running Shoes", product.Name);
        Assert.Equal("Lightweight trainers", product.Description);
        Assert.Equal(199.90m, product.Price);
        Assert.Equal("shoes.png", product.PictureFileName);
        Assert.Equal(1, product.CatalogTypeId);
        Assert.Equal(2, product.CatalogBrandId);
    }

    [Fact]
    public void Constructor_WithEmptyId_ThrowsArgumentException()
    {
        var exception = Assert.Throws<ArgumentException>(() =>
            new Product(Guid.Empty, "Running Shoes", "desc", 10m, "pic.png", 1, 1));

        Assert.Equal("id", exception.ParamName);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_WithInvalidName_ThrowsArgumentException(string? name)
    {
        var exception = Assert.Throws<ArgumentException>(() =>
            new Product(ValidId, name!, "desc", 10m, "pic.png", 1, 1));

        Assert.Equal("name", exception.ParamName);
    }

    [Fact]
    public void Constructor_WithNegativePrice_ThrowsArgumentException()
    {
        var exception = Assert.Throws<ArgumentException>(() =>
            new Product(ValidId, "Running Shoes", "desc", -0.01m, "pic.png", 1, 1));

        Assert.Equal("price", exception.ParamName);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Constructor_WithInvalidCatalogTypeId_ThrowsArgumentException(int catalogTypeId)
    {
        var exception = Assert.Throws<ArgumentException>(() =>
            new Product(ValidId, "Running Shoes", "desc", 10m, "pic.png", catalogTypeId, 1));

        Assert.Equal("catalogTypeId", exception.ParamName);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Constructor_WithInvalidCatalogBrandId_ThrowsArgumentException(int catalogBrandId)
    {
        var exception = Assert.Throws<ArgumentException>(() =>
            new Product(ValidId, "Running Shoes", "desc", 10m, "pic.png", 1, catalogBrandId));

        Assert.Equal("catalogBrandId", exception.ParamName);
    }

    [Fact]
    public void Constructor_AllowsZeroPriceAndEmptyOptionalText()
    {
        var product = new Product(ValidId, "Free Sample", null!, 0m, null!, 1, 1);

        Assert.Equal(0m, product.Price);
        Assert.Equal(string.Empty, product.Description);
        Assert.Equal(string.Empty, product.PictureFileName);
    }

    [Fact]
    public void UpdateDetails_WithValidData_ChangesMutableStateWithoutChangingId()
    {
        var product = CreateValidProduct();

        product.UpdateDetails("Trail Shoes", "Waterproof", 249.50m, "trail.png", 3, 4);

        Assert.Equal(ValidId, product.Id);
        Assert.Equal("Trail Shoes", product.Name);
        Assert.Equal("Waterproof", product.Description);
        Assert.Equal(249.50m, product.Price);
        Assert.Equal("trail.png", product.PictureFileName);
        Assert.Equal(3, product.CatalogTypeId);
        Assert.Equal(4, product.CatalogBrandId);
    }

    [Fact]
    public void UpdateDetails_WithInvalidName_KeepsPreviousState()
    {
        var product = CreateValidProduct();

        Assert.Throws<ArgumentException>(() =>
            product.UpdateDetails(" ", "new desc", 10m, "new.png", 8, 9));

        Assert.Equal("Running Shoes", product.Name);
        Assert.Equal("Lightweight trainers", product.Description);
        Assert.Equal(199.90m, product.Price);
        Assert.Equal("shoes.png", product.PictureFileName);
        Assert.Equal(1, product.CatalogTypeId);
        Assert.Equal(2, product.CatalogBrandId);
    }
}
