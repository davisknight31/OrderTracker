using Microsoft.EntityFrameworkCore;
using OrderTracker.Api.Data;
using OrderTracker.Api.Models;

namespace OrderTracker.Api.Services;

public class ProductService(AppDbContext db)
{
    public Task<List<Product>> GetAllProductsAsync() 
    {
        return db.Products
            .ToListAsync();
    }

    public Task<Product?> GetProductByIdAsync(int id)
    {
        return db.Products
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
        await db.Products.AddAsync(product);
        await db.SaveChangesAsync();
        return product;
    }
}
