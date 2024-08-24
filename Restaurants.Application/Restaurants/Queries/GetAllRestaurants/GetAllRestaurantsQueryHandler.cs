
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants;

public class GetAllRestaurantsQueryHandler(ILogger<GetAllRestaurantsQueryHandler> logger, IMapper mapper, IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetAllRestarantsQuery, IEnumerable<RestaurantDto>>
{
    public async Task<IEnumerable<RestaurantDto>> Handle(GetAllRestarantsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all restaurant");
        var restaurants = await restaurantsRepository.GetAllAsync();
        var restaurantsDto = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
        return restaurantsDto;
    }
}
