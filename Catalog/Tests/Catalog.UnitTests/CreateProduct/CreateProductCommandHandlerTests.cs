
using Catalog.Application.Products.CreateProduct;
using FluentValidation;

namespace Catalog.UnitTests.CreateProduct
{
    public class CreateProductCommandHandlerTests
    {
        [Fact]
        public void Should_create_product_when_command_is_valid()
        {
            // Arrange
            var service = new FakeCreateProductService();
            var validator = new CreateProductCommandValidator();

            var handler = new CreateProductCommandHandler(service, validator);
            var command = new CreateProductCommand(
                Name: "Valid Product Name", // <-- Nome preenchido
                Description: "Valid Product Description",
                Price: 10.0m,
                PictureFileName: "valid_picture.jpg",
                CatalogTypeId: 1,
                CatalogBrandId: 1
            );

            var response = handler.Handle(command);

            // Assert
            Assert.NotEqual(Guid.Empty, response.ProductId);
            Assert.Equal("Valid Product Name", response.Name);
            Assert.Equal(10.0m, response.Price);
        }

        [Fact]
        public void Should_throw_validation_exception_when_command_is_invalid()
        {
            // Arrange
            var service = new FakeCreateProductService();
            var validator = new CreateProductCommandValidator();
            var handler = new CreateProductCommandHandler(service, validator);
            var command = new CreateProductCommand(
                Name: "",
                Description: "",
                Price: -5.0m,
                PictureFileName: "",
                CatalogTypeId: 0,
                CatalogBrandId: 0
            );

            // Act & Assert
            var exception = Assert.Throws<ValidationException>(() => handler.Handle(command));
            Assert.Contains(exception.Errors, e => e.PropertyName == "Name");
            Assert.Contains(exception.Errors, e => e.PropertyName == "Price");
            Assert.Contains(exception.Errors, e => e.PropertyName == "CatalogTypeId");
            Assert.Contains(exception.Errors, e => e.PropertyName == "CatalogBrandId");
        }

        private sealed class FakeCreateProductService : ICreateProductService
        {
            public CreateProductResponse Execute(CreateProductRequest request)
            {
                return new CreateProductResponse(
                    Guid.NewGuid(),
                    request.Name,
                    request.Description,
                    request.Price,
                    request.PictureFileName,
                    request.CatalogTypeId,
                    request.CatalogBrandId);
            }
        }

    }
}
