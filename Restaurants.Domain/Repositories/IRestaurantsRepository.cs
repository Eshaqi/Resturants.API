using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories;

public interface IRestaurantsRepository
{
    Task<IEnumerable<Restaurant>> GetAllAsync();

    Task<Restaurant?> GetByIdAsync(int id);

    Task<int> Create(Restaurant entity);

    Task<int> Update(int id, Restaurant entity);

    //Task SaveChanges();

    Task Delete(Restaurant entity);
}
