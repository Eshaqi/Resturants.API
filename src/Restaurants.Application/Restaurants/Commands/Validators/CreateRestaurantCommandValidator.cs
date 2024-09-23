using FluentValidation;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;

namespace Restaurants.Application.Restaurants.Commands.Validators;

public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
{
    //private readonly List<string> validCategories = ["Italian", "Mexican", "Japanese", "Indian"];
    public CreateRestaurantCommandValidator()
    {
        RuleFor(dto => dto.Name).NotEmpty().Length(3, 100);
        RuleFor(dto => dto.Description).NotEmpty().WithMessage("Description is required");
        RuleFor(dto => dto.Category).NotEmpty().WithMessage("Category is required");
        RuleFor(dto => dto.ContactEmail).EmailAddress().WithMessage("Please provide a valid email address");
        RuleFor(dto => dto.ContactNumber).Matches(@"^(\(0[2-8]\)|0[2-8])\s?\d{4}\s?\d{4}$|^(04|05)\d{2}\s?\d{3}\s?\d{3}$").WithMessage("Please provide a valid phone number");
        RuleFor(dto => dto.PostalCode).Matches(@"^\d{4}$").WithMessage("please provide a valid postal code");

        //RuleFor(dto => dto.Category).Custom((value, context) =>
        //{
        //    var isValidCategory = validCategories.Contains(value);
        //    if (!isValidCategory)
        //    {
        //        context.AddFailure("Category", "Invalid category, Please choose from valid categories");
        //    }
        //});
    }
}
