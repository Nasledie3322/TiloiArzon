namespace StoreAPI.Entities;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }

    public List<CartItem> CartItems { get; set; }
    public List<Order> Orders { get; set; }
    public List<Favorite> Favorites { get; set; }
}
