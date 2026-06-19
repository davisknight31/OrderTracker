using Microsoft.AspNetCore.Mvc;
using OrderTracker.Api.Models;
using OrderTracker.Api.Services;

namespace OrderTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController(CustomerService customerService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Customer>>> GetAllCustomers()
    {
        var customers = await customerService.GetAllCustomersAsync();
        return Ok(customers);
    }

    [HttpGet("{id:id}")]
    public async Task<ActionResult<Customer>> GetCustomerById(int id)
    {
        var customer = await customerService.GetCustomerByIdAsync(id);
        if (customer == null)
            return NotFound();

        return Ok(customer);
    }

    [HttpPost]
    public async Task<ActionResult<Customer>> Create(Customer customer)
    {
        var created = await customerService.CreateCustomerAsync(customer);
        return Ok(created);
    }
}
