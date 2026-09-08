using FluentValidation;

namespace Catalog.Application.Products.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");

            RuleFor(x => x.PictureFileName)
                .NotEmpty().WithMessage("Picture file name is required.")
                .MaximumLength(200).WithMessage("Picture file name must not exceed 200 characters.");

            RuleFor(x => x.CatalogTypeId)
                .GreaterThan(0).WithMessage("Catalog type ID must be greater than zero.");

            RuleFor(x => x.CatalogBrandId)
                .GreaterThan(0).WithMessage("Catalog brand ID must be greater than zero.");
        }
    }
}