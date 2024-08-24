using MediatR;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants;

public class GetAllRestarantsQuery : IRequest<IEnumerable<RestaurantDto>>
{
}
