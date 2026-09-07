
namespace Catalog.Application.Products.CreateProduct
{
    public record CreateProductRequest(
        Guid Id,
        string Name,
        string Description,
        decimal Price,
        string PictureFileName,
         int CatalogTypeId,
    int CatalogBrandId);
}