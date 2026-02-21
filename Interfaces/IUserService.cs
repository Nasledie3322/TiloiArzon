using StoreAPI.Entities;

public interface IUserService
{
    Task<User> AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(int id);
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id);
}