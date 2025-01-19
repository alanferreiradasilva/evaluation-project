using FluentValidation;

namespace NetCore.Ambev.Application.Carts.Commands.Validations
{
    public class CreateCartCommandValidation : AbstractValidator<CreateCartCommand>
    {
        public CreateCartCommandValidation()
        {
            RuleFor(x => x.Products)
                .NotEmpty().WithMessage("Cart must be almost one product")

                ;

        }
    }
}
