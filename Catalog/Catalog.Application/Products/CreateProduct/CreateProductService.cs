
using Catalog.Domain.Entities;
using Catalog.Domain.Repositories;

namespace Catalog.Application.Products.CreateProduct
{
    public class CreateProductService : ICreateProductService
    {
        private readonly IProductRepository _repository;

        public CreateProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public CreateProductResponse Execute(CreateProductRequest request)
        {
            var productId = request.Id != Guid.Empty ? request.Id : Guid.NewGuid();

            var product = new Product(
                productId,
                request.Name,
                request.Description,
                request.Price,
                request.PictureFileName,
                request.CatalogTypeId,
                request.CatalogBrandId);

            _repository.Add(product);

            return new CreateProductResponse(
                product.Id,
                product.Name,
                product.Description,
                product.Price,
                product.PictureFileName,
                product.CatalogTypeId,
                product.CatalogBrandId);
        }
    }
}