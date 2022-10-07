using FluentValidation;

using Global.Common.Sources.Errors;

using Ecommerce.Domain.DTOs;

namespace Ecommerce.Domain.Validations;

public sealed class UpdateProductDTOValidations : AbstractValidator<UpdateProductDTO>
{
    public UpdateProductDTOValidations()
    {
        RuleFor(x => x.Name)
            .Cascade(CascadeMode.Continue)
            .NotEmpty()
                .WithMessage(ExceptionsTranslated.requiredField)
            .MinimumLength(5)
                .WithMessage(ExceptionsTranslated.shortField)
            .MaximumLength(40)
                .WithMessage(ExceptionsTranslated.longField);

        RuleFor(x => x.Price)
            .Cascade(CascadeMode.Continue)
            .NotEmpty()
                .WithMessage(ExceptionsTranslated.requiredField);

        RuleFor(x => x.Stock)
            .Cascade(CascadeMode.Continue)
            .NotEmpty()
                .WithMessage(ExceptionsTranslated.requiredField);
    }
}
