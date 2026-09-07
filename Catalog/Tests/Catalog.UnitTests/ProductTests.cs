using Catalog.Domain.Entities;

namespace Catalog.UnitTests;

public class UnitTest1
{
    [Fact]
    public void Should_Create_Product_With_Valid_Data()
    {
        var product = new Product(Guid.NewGuid(), "Test Product", 10.99m, "Test Description", "nootbook.jpg", 1, 1);

        Assert.NotNull(product);
        Assert.Equal("Test Product", product.Name);
        Assert.Equal("Test Description", product.Description);
        Assert.Equal("nootbook.jpg", product.PictureFileName);
        Assert.Equal(1, product.CatalogBrandId);
        Assert.Equal(1, product.CatalogTypeId);

    }

    [Fact]
    public void Should_Reject_Negative_Price()
    {
        Assert.Throws<ArgumentException>(() => new Product(Guid.NewGuid(), "Test Product", -10.99m, "Test Description", "nootbook.jpg", 1, 1));
    }

    [Fact]
    public void Should_Reject_Empty_Product_Name()
    {
        Assert.Throws<ArgumentException>(() => new Product(Guid.NewGuid(), "", 10.99m, "Test Description", "nootbook.jpg", 1, 1));
    }

    [Fact]
    public void Should_Update_Product_Price()
    {

    }
}
