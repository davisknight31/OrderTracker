using Microsoft.EntityFrameworkCore;
using OrderTracker.Api.Data;
using OrderTracker.Api.Models;

namespace OrderTracker.Api.Services;

public class OrderService(AppDbContext db)
{
    public Task<List<Order>> GetAllOrdersAsync()
    {
        return OrdersWithDetails()
            .ToListAsync();
    }

    public Task<Order?> GetOrderByIdAsync(int id)
    {
        return OrdersWithDetails()
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<Order> CreateAsync(Order order)
    {
        await db.Orders.AddAsync(order);
        await db.SaveChangesAsync();
        return order;
    }

    private IQueryable<Order> OrdersWithDetails()
    {
        return db.Orders
            .Include(o => o.Customer)
            .Include(o => o.OrderItems)
            .ThenInclude(i => i.Product);
    }
}
