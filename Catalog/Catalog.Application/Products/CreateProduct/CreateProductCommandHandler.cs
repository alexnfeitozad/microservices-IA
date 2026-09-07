
namespace Catalog.Application.Products.CreateProduct
{
    public class CreateProductCommandHandler
    {
        private readonly CreateProductService _createProductService;

        public CreateProductCommandHandler(CreateProductService createProductService)
        {
            _createProductService = createProductService;
        }

        public CreateProductResponse Handle(CreateProductCommand command)
        {
            var request = new CreateProductRequest(
                Guid.NewGuid(),
                command.Name,
                command.Description,
                command.Price,
                command.PictureFileName,
                command.CatalogTypeId,
                command.CatalogBrandId);

            return _createProductService.CreateProduct(request);
        }
    }
}