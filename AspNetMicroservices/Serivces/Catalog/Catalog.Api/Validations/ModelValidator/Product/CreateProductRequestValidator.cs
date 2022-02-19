using Catalog.Entities.ApiEntities.Product.Request;
using FluentValidation;

namespace Catalog.Api.Validations.ModelValidator.Product
{
    public class CreateProductRequestValidator: AbstractValidator<CreateProductRequest>
    {
        public CreateProductRequestValidator()
        {
            RuleFor(c=>c.Summery).NotEmpty()
                .WithMessage("{PropertyName} Is Required");

            RuleFor(c => c.Name).NotEmpty()
            .WithMessage("{PropertyName} Is Required");

            RuleFor(c => c.Price).NotEmpty()
            .WithMessage("{PropertyName} Is Required");

            RuleFor(c => c.Code).NotEmpty()
            .WithMessage("{PropertyName} Is Required");

            RuleFor(c => c.Category).NotEmpty()
            .WithMessage("{PropertyName} Is Required");

            RuleFor(c => c.Description).NotEmpty()
            .WithMessage("{PropertyName} Is Required");

            RuleFor(c => c.ImageFile).NotEmpty()
            .WithMessage("{PropertyName} Is Required");
        }
    }
}
