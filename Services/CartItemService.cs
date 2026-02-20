using Microsoft.EntityFrameworkCore;
using StoreAPI.Data;
using StoreAPI.Entities;

public class CartItemService : ICartItemService
{
    private readonly AppDbContext _context;

    public CartItemService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<CartItem>> GetAllAsync()
    {
        return await _context.CartItems
            .Include(c => c.Product)
            .Include(c => c.User)
            .ToListAsync();
    }

    public async Task<CartItem?> GetByIdAsync(int id)
    {
        return await _context.CartItems.FindAsync(id);
    }

    public async Task<CartItem> CreateAsync(CartItem item)
    {
        _context.CartItems.Add(item);
        await _context.SaveChangesAsync();
        return item;
    }

    public async Task UpdateAsync(CartItem item)
    {
        _context.CartItems.Update(item);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var item = await _context.CartItems.FindAsync(id);
        if (item != null)
        {
            _context.CartItems.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
