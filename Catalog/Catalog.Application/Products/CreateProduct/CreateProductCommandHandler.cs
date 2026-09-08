
using FluentValidation;

namespace Catalog.Application.Products.CreateProduct
{
    public class CreateProductCommandHandler
    {
        private readonly CreateProductService _createProductService;
        private readonly IValidator<CreateProductCommand> _validator;
        public CreateProductCommandHandler(CreateProductService createProductService, IValidator<CreateProductCommand> validator)
        {
            _createProductService = createProductService;
            _validator = validator;
        }

        public CreateProductResponse Handle(CreateProductCommand command)
        {
            _validator.ValidateAndThrow(command);
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