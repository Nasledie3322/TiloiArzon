using StoreAPI.Entities;

public interface IOrderService
{
    Task<List<Order>> GetAllAsync();
    Task<Order?> GetByIdAsync(int id);
    Task<Order> CreateAsync(Order order);
}
