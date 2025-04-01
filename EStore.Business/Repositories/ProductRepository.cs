using EStore.Data.Models;
using EStore.Data.Repositories;

namespace EStore.Business.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Task<Product> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Product>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
