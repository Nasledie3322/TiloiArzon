using StoreAPI.Entities;

public interface ICartItemService
{
    Task<List<CartItem>> GetAllAsync();
    Task<CartItem?> GetByIdAsync(int id);
    Task<CartItem> CreateAsync(CartItem item);
    Task UpdateAsync(CartItem item);
    Task DeleteAsync(int id);
}
