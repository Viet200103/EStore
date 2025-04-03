using EStore.Data.Models;

namespace EStore.Data.Repositories;

public interface IProductRepository
{
    public Task<IList<Product>> GetProductsAsync();
    public Task<Product> GetProductByIdAsync(int id);
}