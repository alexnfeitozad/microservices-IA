using Catalog.Domain.Entities;

namespace Catalog.UnitTests.Entities;

public class ProductTests
{
    private static readonly Guid ValidId = Guid.Parse("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");

    private static Product CreateValidProduct() =>
        new(ValidId, "Running Shoes", "Lightweight trainers", 199.90m, "shoes.png", 1, 2);

    private static void AssertProduct(
        Product product,
        Guid id,
        string name,
        string description,
        decimal price,
        string pictureFileName,
        int catalogTypeId,
        int catalogBrandId)
    {
        Assert.Equal(id, product.Id);
        Assert.Equal(name, product.Name);
        Assert.Equal(description, product.Description);
        Assert.Equal(price, product.Price);
        Assert.Equal(pictureFileName, product.PictureFileName);
        Assert.Equal(catalogTypeId, product.CatalogTypeId);
        Assert.Equal(catalogBrandId, product.CatalogBrandId);
    }

    private static void AssertUnchangedValidProduct(Product product) =>
        AssertProduct(product, ValidId, "Running Shoes", "Lightweight trainers", 199.90m, "shoes.png", 1, 2);

    [Fact]
    public void Constructor_WithValidData_AssignsIdentityAndState()
    {
        var product = CreateValidProduct();

        AssertUnchangedValidProduct(product);
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

        AssertProduct(product, ValidId, "Trail Shoes", "Waterproof", 249.50m, "trail.png", 3, 4);
    }

    [Fact]
    public void UpdateDetails_AllowsZeroPriceAndEmptyOptionalText()
    {
        var product = CreateValidProduct();

        product.UpdateDetails("Free Sample", null!, 0m, null!, 1, 1);

        AssertProduct(product, ValidId, "Free Sample", string.Empty, 0m, string.Empty, 1, 1);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void UpdateDetails_WithInvalidName_KeepsPreviousState(string? name)
    {
        var product = CreateValidProduct();

        var exception = Assert.Throws<ArgumentException>(() =>
            product.UpdateDetails(name!, "new desc", 10m, "new.png", 8, 9));

        Assert.Equal("name", exception.ParamName);
        AssertUnchangedValidProduct(product);
    }

    [Fact]
    public void UpdateDetails_WithNegativePrice_KeepsPreviousState()
    {
        var product = CreateValidProduct();

        var exception = Assert.Throws<ArgumentException>(() =>
            product.UpdateDetails("Trail Shoes", "new desc", -0.01m, "new.png", 8, 9));

        Assert.Equal("price", exception.ParamName);
        AssertUnchangedValidProduct(product);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void UpdateDetails_WithInvalidCatalogTypeId_KeepsPreviousState(int catalogTypeId)
    {
        var product = CreateValidProduct();

        var exception = Assert.Throws<ArgumentException>(() =>
            product.UpdateDetails("Trail Shoes", "new desc", 10m, "new.png", catalogTypeId, 9));

        Assert.Equal("catalogTypeId", exception.ParamName);
        AssertUnchangedValidProduct(product);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void UpdateDetails_WithInvalidCatalogBrandId_KeepsPreviousState(int catalogBrandId)
    {
        var product = CreateValidProduct();

        var exception = Assert.Throws<ArgumentException>(() =>
            product.UpdateDetails("Trail Shoes", "new desc", 10m, "new.png", 8, catalogBrandId));

        Assert.Equal("catalogBrandId", exception.ParamName);
        AssertUnchangedValidProduct(product);
    }
}
