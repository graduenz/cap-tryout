using CapTryout.Domain.Dto;
using FluentValidation;

namespace CapTryout.Domain.Validators;
public class MealDtoValidator : AbstractValidator<MealDto>
{
    public MealDtoValidator()
    {
        RuleFor(m => m.Name)
            .NotEmpty()
            .MinimumLength(3);

        RuleFor(m => m.Rating)
            .InclusiveBetween(0, 10);
    }
}