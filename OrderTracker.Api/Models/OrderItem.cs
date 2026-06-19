using System.Text.Json.Serialization;

namespace OrderTracker.Api.Models;

public class OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; }

    [JsonIgnore]
    public Order Order { get; set; } = null!;
    public int? ProductId { get; set; }
    public Product? Product { get; set; }
    public string Description { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
