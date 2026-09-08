
using FluentValidation;

namespace Catalog.Application.Products.CreateProduct
{
    public class CreateProductCommandHandler
    {
        private readonly ICreateProductService _service;
        private readonly IValidator<CreateProductCommand> _validator;
        public CreateProductCommandHandler(ICreateProductService createProductService,
         IValidator<CreateProductCommand> validator)
        {
            _service = createProductService;
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

            return _service.Execute(request);
        }
    }
}