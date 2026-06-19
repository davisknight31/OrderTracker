using Microsoft.AspNetCore.Mvc;
using OrderTracker.Api.Models;
using OrderTracker.Api.Services;

namespace OrderTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController(OrderService orderService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Order>>> GetAllOrders()
    {
        var orders = await orderService.GetAllOrdersAsync();
        return Ok(orders);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Order>> GetByOrderId(int id)
    {
        var order = await orderService.GetOrderByIdAsync(id);
        if (order is null)
            return NotFound();

        return Ok(order);
    }

    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrder(Order order)
    {
        var created = await orderService.CreateOrderAsync(order);
        return Ok(created);
    }
}
