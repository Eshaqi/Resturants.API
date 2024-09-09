using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;

namespace Restaurants.Application.Restaurants.Queries.Validators;

public class GetAllRestaurantQueryValidator : AbstractValidator<GetAllRestarantsQuery>
{
    private int[] allowPageSize = [5, 10, 15, 30];
    private string[] allowedSortByColumnNames = [nameof(RestaurantDto.Name), nameof(RestaurantDto.Description), nameof(RestaurantDto.Category)];

    public GetAllRestaurantQueryValidator()
    {
        RuleFor(r => r.PageNumber).GreaterThanOrEqualTo(1);

        RuleFor(r => r.PageSize).Must(value => allowPageSize.Contains(value)).WithMessage($"Page size must be in [{string.Join(",", allowPageSize)}]");

        RuleFor(r => r.SortBy).Must(value => allowedSortByColumnNames.Contains(value)).When(q => q.SortBy != null).WithMessage($"Sort by is optional, or mus be in [{string.Join(",", allowedSortByColumnNames)}]");
    }
}
