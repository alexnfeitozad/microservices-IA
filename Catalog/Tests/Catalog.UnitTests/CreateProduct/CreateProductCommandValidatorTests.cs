using Catalog.Application.Products.CreateProduct;

namespace Catalog.UnitTests.CreateProduct
{
    public class CreateProductCommandValidatorTests
    {
        [Fact]
        public void Should_be_valid_when_command_is_valid()
        {
            // Arrange
            var validator = new CreateProductCommandValidator();

            var command = new CreateProductCommand(
                Name: "Valid Product Name", // <-- Nome preenchido
                Description: "Valid Product Description",
                Price: 10.0m,
                PictureFileName: "valid_picture.jpg",
                CatalogTypeId: 1,
                CatalogBrandId: 1
            );

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }
    }
}