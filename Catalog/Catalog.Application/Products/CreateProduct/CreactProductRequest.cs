
namespace Catalog.Application.Products.CreateProduct
{
    public record CreactProductRequest(
        string Name,
        string Description,
        decimal Price,
        string PictureFileName,
         int CatalogTypeId,
    int CatalogBrandId);
}