using EStore.Data.Models;

namespace EStore.Data.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetAllProductAsync();
    Task<Product> GetProductByIdAsync(int id);
    Task<bool> AddProductAsync(Product product);
    Task<bool> DeleteProductAsync(int id);
    Task<bool> UpdateProductAsync(Product product);
    Task<Product> GetProductForUpdateAsync(int id);




}