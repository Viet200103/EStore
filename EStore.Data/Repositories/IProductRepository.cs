using EStore.Data.Models;

namespace EStore.Data.Repositories;

public interface IProductRepository
{
    Task<IList<Product>> GetAvailableProductsAsync();
    Task<Product?> GetProductByIdAsync(int id);
}