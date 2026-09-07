
namespace Catalog.Application.Products.CreateProduct
{
    public record CreateProductCommand(
        string Name,
        string Description,
        decimal Price,
        string PictureFileName,
        int CatalogTypeId,
        int CatalogBrandId);
}