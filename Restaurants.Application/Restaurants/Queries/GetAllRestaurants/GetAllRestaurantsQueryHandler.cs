
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Common;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants;

public class GetAllRestaurantsQueryHandler(ILogger<GetAllRestaurantsQueryHandler> logger, IMapper mapper, IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetAllRestarantsQuery, PageResult<RestaurantDto>>
{
    public async Task<PageResult<RestaurantDto>> Handle(GetAllRestarantsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all restaurant");

        var (restaurants, totalCount) = await restaurantsRepository.GetAllMatchingAsync(request.SearchPhrase, request.PageSize, request.PageNumber, request.SortBy, request.SortDirection);

        
        var restaurantsDto = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

        var result = new PageResult<RestaurantDto>(restaurantsDto, totalCount, request.PageSize, request.PageNumber);

        return result;
    }
}
