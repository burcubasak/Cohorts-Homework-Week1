using Cohorts_Homework_Week1.Models;
using FluentValidation;

namespace Cohorts_Homework_Week1.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Product name is required")
               .MinimumLength(3).WithMessage("Product name must be at least 3 characters long");
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");
            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("Stock must be greater than or equal to 0");
        }

    }
}
