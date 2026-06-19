namespace OrderTracker.Api.Models;

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal DefaultPrice { get; set; }
}
