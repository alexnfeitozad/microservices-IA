
namespace Catalog.Application.Products.CreateProduct
{
    public record CreateProductResponse(
        Guid Id,
        string Name,
        string Description,
        decimal Price,
        string PictureFileName,
        int CatalogTypeId,
        int CatalogBrandId)
    {
        // Alias de compatibilidade com o contrato antigo de testes e ensino.
        public Guid ProductId => Id;
    }
}