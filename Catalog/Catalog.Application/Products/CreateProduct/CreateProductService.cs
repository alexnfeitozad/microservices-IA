
using Catalog.Domain.Entities;

namespace Catalog.Application.Products.CreateProduct
{
    public class CreateProductService
    {
        public CreateProductResponse CreateProduct(CreateProductRequest request)
        {
            var product = new Product(
                Guid.NewGuid(),
                request.Name,
                request.Description,
                request.Price,
                request.PictureFileName,
                request.CatalogTypeId,
                request.CatalogBrandId);

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