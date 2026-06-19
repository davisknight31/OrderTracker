namespace OrderTracker.Api.Models;

public class Customer
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? ContactInfo { get; set; }
    public string? Notes { get; set; }
}
