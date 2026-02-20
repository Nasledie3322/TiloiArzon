using Microsoft.EntityFrameworkCore;
using StoreAPI.Data;
using StoreAPI.Entities;

public class FavoriteService : IFavoriteService
{
    private readonly AppDbContext _context;

    public FavoriteService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Favorite>> GetAllAsync()
    {
        return await _context.Favorites
            .Include(f => f.Product)
            .Include(f => f.User)
            .ToListAsync();
    }

    public async Task<Favorite> CreateAsync(Favorite favorite)
    {
        _context.Favorites.Add(favorite);
        await _context.SaveChangesAsync();
        return favorite;
    }

    public async Task DeleteAsync(int id)
    {
        var fav = await _context.Favorites.FindAsync(id);
        if (fav != null)
        {
            _context.Favorites.Remove(fav);
            await _context.SaveChangesAsync();
        }
    }
}
