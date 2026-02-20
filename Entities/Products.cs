namespace StoreAPI.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public string ImageUrl { get; set; }

    public Category Category { get; set; }
    public List<CartItem> CartItems { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    public List<Favorite> Favorites { get; set; }
}
