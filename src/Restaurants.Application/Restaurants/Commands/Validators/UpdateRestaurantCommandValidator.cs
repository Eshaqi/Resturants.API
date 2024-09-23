using FluentValidation;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

namespace Restaurants.Application.Restaurants.Commands.Validators;

public class UpdateRestaurantCommandValidator : AbstractValidator<UpdateRestaurantCommand>
{
    public UpdateRestaurantCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().Length(3, 100);
        RuleFor(c => c.Description).NotEmpty().WithMessage("Description is required");
        RuleFor(c => c.Category).NotEmpty().WithMessage("Category is required");
        RuleFor(c => c.ContactEmail).EmailAddress().WithMessage("Please provide a valid email address");
        RuleFor(c => c.ContactNumber).Matches(@"^(\(0[2-8]\)|0[2-8])\s?\d{4}\s?\d{4}$|^(04|05)\d{2}\s?\d{3}\s?\d{3}$").WithMessage("Please provide a valid phone number");
        RuleFor(c => c.PostalCode).Matches(@"^\d{4}$").WithMessage("please provide a valid postal code");
    }
    
}
