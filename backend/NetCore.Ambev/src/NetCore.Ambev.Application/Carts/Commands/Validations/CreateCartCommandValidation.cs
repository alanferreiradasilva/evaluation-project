using FluentValidation;

namespace NetCore.Ambev.Application.Carts.Commands.Validations
{
    public class CreateCartCommandValidation : AbstractValidator<CreateCartCommand>
    {
        public CreateCartCommandValidation()
        {
            RuleFor(x => x.Products)
                .NotNull()
                    .WithMessage("Invalid Cart Product list. Cart must be almost one product.")
                .NotEmpty()
                    .WithMessage("Cart must be almost one product.")
                .Must(products => products.All(product => product.ProductId > 0 && product.Quantity > 0))
                    .WithMessage("Invalid Cart Product. ProductId and Quantity must be greater than zero.");
            ;
        }
    }
}
