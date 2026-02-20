using Microsoft.EntityFrameworkCore;
using StoreAPI.Data;
using StoreAPI.Entities;

public class OrderService : IOrderService
{
    private readonly AppDbContext _context;

    public OrderService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Order>> GetAllAsync()
    {
        return await _context.Orders
            .Include(o => o.Items)
            .ToListAsync();
    }

    public async Task<Order?> GetByIdAsync(int id)
    {
        return await _context.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<Order> CreateAsync(Order order)
    {
        order.CreatedAt = DateTime.UtcNow;

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return order;
    }
}
