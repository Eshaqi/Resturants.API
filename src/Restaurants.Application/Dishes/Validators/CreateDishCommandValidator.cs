using FluentValidation;
using Restaurants.Application.Dishes.Commands.CreateDish;

namespace Restaurants.Application.Dishes.Validators;

public class CreateDishCommandValidator : AbstractValidator<CreateDishCommand>
{
    public CreateDishCommandValidator()
    {
        RuleFor(dish => dish.Price).GreaterThanOrEqualTo(0).WithMessage("Price must be non-negative number");
        RuleFor(dish => dish.KiloCalories).GreaterThanOrEqualTo(0).WithMessage("Kilo Calories must be non-negative number");
    }
}
