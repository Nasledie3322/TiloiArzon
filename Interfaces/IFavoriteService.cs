using StoreAPI.Entities;

public interface IFavoriteService
{
    Task<List<Favorite>> GetAllAsync();
    Task<Favorite> CreateAsync(Favorite favorite);
    Task DeleteAsync(int id);
}
