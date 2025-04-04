using EStore.Data.Models;

namespace EStore.Data.Repositories;

public interface IProductRepository
{
    Task<(IEnumerable<Product> products, int totalPages)> GetProducts(int pageNumber, int pageSize, string? search = null, string? condition = null);
    
    Task<Product?> GetProductById(int id);
    Task<bool> AddProduct(Product product);
    Task<bool> DeleteProductAsync(int id);
    Task<bool> UpdateProductAsync(Product product);
}