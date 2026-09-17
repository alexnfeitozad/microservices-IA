using Catalog.Application.Products.CreateProduct;
using Catalog.Domain.Entities;
using Catalog.Domain.Repositories;

namespace Catalog.UnitTests.CreateProduct
{
    public class CreateProductServiceTests
    {
        [Fact]
        public void Execute_WithProvidedId_CreatesProductWithGivenId()
        {
            // Arrange
            var repository = new FakeProductRepository();
            var service = new CreateProductService(repository);
            var expectedId = Guid.NewGuid();
            var request = new CreateProductRequest(
                expectedId,
                "Test Product",
                "Test Description",
                99.99m,
                "test.png",
                1,
                2);

            // Act
            var response = service.Execute(request);

            // Assert
            Assert.Equal(expectedId, response.Id);
            Assert.Equal(expectedId, response.ProductId);
            Assert.NotNull(repository.AddedProduct);
            Assert.Equal(expectedId, repository.AddedProduct!.Id);
            Assert.Equal("Test Product", repository.AddedProduct.Name);
        }

        [Fact]
        public void Execute_WithEmptyId_GeneratesNewId()
        {
            // Arrange
            var repository = new FakeProductRepository();
            var service = new CreateProductService(repository);
            var request = new CreateProductRequest(
                Guid.Empty,
                "Test Product",
                "Test Description",
                99.99m,
                "test.png",
                1,
                2);

            // Act
            var response = service.Execute(request);

            // Assert
            Assert.NotEqual(Guid.Empty, response.Id);
            Assert.NotNull(repository.AddedProduct);
            Assert.Equal(response.Id, repository.AddedProduct!.Id);
        }

        private sealed class FakeProductRepository : IProductRepository
        {
            public Product? AddedProduct { get; private set; }

            public void Add(Product product)
            {
                AddedProduct = product;
            }
        }
    }
}

