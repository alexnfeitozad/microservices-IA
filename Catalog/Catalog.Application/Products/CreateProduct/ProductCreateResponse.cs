
namespace Catalog.Application.Products.CreateProduct
{
    public record ProductCreateResponse(
        int Id,
        string Name,
        string Description,
        decimal Price,
        string PictureFileName,
         int CatalogTypeId,
    int CatalogBrandId);
}