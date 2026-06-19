using Microsoft.EntityFrameworkCore;
using OrderTracker.Api.Data;
using OrderTracker.Api.Models;

namespace OrderTracker.Api.Services;

public class CustomerService(AppDbContext db)
{
    public Task<List<Customer>> GetAllCustomersAsync() 
    {
        return db.Customers.ToListAsync();
    }

    public Task<Customer?> GetCustomerByIdAsync(int id) 
    {
        return db.Customers.FirstOrDefaultAsync(c => c.Id == id);
    }
        

    public async Task<Customer> CreateCustomerAsync(Customer customer)
    {
        await db.Customers.AddAsync(customer);
        await db.SaveChangesAsync();
        return customer;
    }
}
